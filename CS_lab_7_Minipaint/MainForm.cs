using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CS_lab_7_Minipaint
{
    public partial class MainForm : Form
    {
        private bool isMouseButtonPressed = false;

        private Point pointStart;
        private Point pointCurrent;
        private Point pointBeforeCurrent;

        private Graphics g;

        private delegate void DrawFigure();

        private DrawFigure figure;

        private string curveLine = "Кривая";
        private string straightLine = "Прямая";
        private string rectangle = "Прямоугольник";
        private string ellipse = "Эллипс";

        private List<int> currentFigure;

        private List<List<int>> content = new List<List<int>>();

        private int x;
        private int y;
        private int xDifference; //Длина по оси oX.
        private int yDifference; //Длина по оси oY.

        private Pen pen;

        public MainForm()
        {
            InitializeComponent();
            comboBoxFigure.Items.AddRange(new object[] {
            curveLine,
            straightLine,
            rectangle,
            ellipse});

            comboBoxFigure.SelectedIndex = 0;
            pen = new Pen(labelColorImage.BackColor, (float)numericUpDownWidth.Value);
            g = panelPainting.CreateGraphics();
            DoubleBuffered = true; //Умен. мерцания.
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //Сглаживание.
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round; //Круглое завершение отрезков.
            figure = DrawCurveLine;
        }

        /// <summary>
        /// Если нажат блок выбора цвета.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelColorImage_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                labelColorImage.BackColor = colorDialog.Color;
                pen.Color = colorDialog.Color;
            }
        }

        /// <summary>
        /// Если нажата кнопка "Очистить".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            content.Clear();
            panelPainting.Refresh();
        }

        /// <summary>
        /// Если кнопка мыши отпущена.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelPainting_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseButtonPressed = false;

            if (figure == DrawStraightLine)
            {
                currentFigure.AddRange(new int[] { pointCurrent.X, pointCurrent.Y });
            }

            else if (figure == DrawRectangle || figure == DrawEllipse)
            {
                currentFigure.AddRange(new int[] { x, y, xDifference, yDifference });
            }

            content.Add(currentFigure);
        }

        /// <summary>
        /// Если курсор движется по холсту.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelPainting_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseButtonPressed)
            {
                pointBeforeCurrent = pointCurrent;
                pointCurrent = e.Location;

                if (figure != DrawCurveLine)
                {
                    panelPainting.Invalidate(); //Перерисовка, чтобы видеть, что мы рисуем.
                }

                figure();
            }
        }

        /// <summary>
        /// Если нажимаем кнопку мыши на холсте.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelPainting_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseButtonPressed = true;
            currentFigure = new List<int>();
            pointStart = e.Location;
            pointCurrent = e.Location;

            if (figure == DrawCurveLine)
            {
                currentFigure.AddRange(new int[] { 0, pen.Color.ToArgb(), (int)pen.Width, pointStart.X, pointStart.Y });
            }

            else if (figure == DrawStraightLine)
            {
                currentFigure.AddRange(new int[] { 1, pen.Color.ToArgb(), (int)pen.Width, pointStart.X, pointStart.Y });
            }

            else if (figure == DrawRectangle)
            {
                currentFigure.AddRange(new int[] { 2, pen.Color.ToArgb(), (int)pen.Width });
            }

            else if (figure == DrawEllipse)
            {
                currentFigure.AddRange(new int[] { 3, pen.Color.ToArgb(), (int)pen.Width });
            }
        }

        /// <summary>
        /// Рисование кривой.
        /// </summary>
        private void DrawCurveLine()
        {
            g.DrawLine(pen, pointBeforeCurrent, pointCurrent);
            currentFigure.AddRange(new int[] { pointCurrent.X, pointCurrent.Y });
        }

        /// <summary>
        /// Рисование прямой.
        /// </summary>
        private void DrawStraightLine()
        {
            g.DrawLine(pen, pointStart, pointCurrent);
        }

        /// <summary>
        /// Рисование прямоугольника.
        /// </summary>
        private void DrawRectangle()
        {
            xDifference = pointCurrent.X - pointStart.X;
            yDifference = pointCurrent.Y - pointStart.Y;

            //Если потянули при рисовании прямоугольника влево.
            if (xDifference < 0)
            {
                x = pointCurrent.X;
                xDifference = -xDifference;
            }

            //Если вправо.
            else
            {
                x = pointStart.X;
            }

            //Если потянули при рисовании прямоугльника вверх.
            if (yDifference < 0)
            {
                y = pointCurrent.Y;
                yDifference = -yDifference;
            }

            //Если вниз.
            else
            {
                y = pointStart.Y;
            }

            g.DrawRectangle(pen, x, y, xDifference, yDifference);
        }

        /// <summary>
        /// Рисование эллипса.
        /// </summary>
        private void DrawEllipse()
        {
            xDifference = pointCurrent.X - pointStart.X;
            yDifference = pointCurrent.Y - pointStart.Y;

            //Если потянули при рисовании эллипса влево.
            if (xDifference < 0)
            {
                x = pointCurrent.X;
                xDifference = -xDifference;
            }

            //Если вправо.
            else
            {
                x = pointStart.X;
            }

            //Если потянули при рисовании эллипса вверх.
            if (yDifference < 0)
            {
                y = pointCurrent.Y;
                yDifference = -yDifference;
            }

            //Если вниз.
            else
            {
                y = pointStart.Y;
            }

            g.DrawEllipse(pen, x, y, xDifference, yDifference);
        }

        /// <summary>
        /// Если меняем фигуру.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFigure.SelectedItem.ToString() == curveLine)
            {
                figure = DrawCurveLine;
            }

            else if (comboBoxFigure.SelectedItem.ToString() == straightLine)
            {
                figure = DrawStraightLine;
            }

            else if (comboBoxFigure.SelectedItem.ToString() == rectangle)
            {
                figure = DrawRectangle;
            }

            else if (comboBoxFigure.SelectedItem.ToString() == ellipse)
            {
                figure = DrawEllipse;
            }
        }

        /// <summary>
        /// Перерисовка холста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelPainting_Paint(object sender, PaintEventArgs e)
        {
            //Перебираем все нарисованные фигуры.
            foreach (List<int> drawnFigure in content)
            {
                //Если фигура - кривая.
                if (drawnFigure[0] == 0)
                {
                    pen.Color = Color.FromArgb(drawnFigure[1]);
                    pen.Width = drawnFigure[2];

                    for (int i = 3; i < drawnFigure.Count - 2; i += 2)
                    {
                        g.DrawLine(pen, drawnFigure[i], drawnFigure[i + 1], drawnFigure[i + 2], drawnFigure[i + 3]);
                    }
                }

                //Если фигура - прямая.
                else if (drawnFigure[0] == 1)
                {
                    pen.Color = Color.FromArgb(drawnFigure[1]);
                    pen.Width = drawnFigure[2];

                    g.DrawLine(pen, drawnFigure[3], drawnFigure[4], drawnFigure[5], drawnFigure[6]);
                }

                //Если фигура - прямоугольник.
                else if (drawnFigure[0] == 2)
                {
                    pen.Color = Color.FromArgb(drawnFigure[1]);
                    pen.Width = drawnFigure[2];

                    g.DrawRectangle(pen, drawnFigure[3], drawnFigure[4], drawnFigure[5], drawnFigure[6]);
                }

                //Если фигура - эллипс.
                else if (drawnFigure[0] == 3)
                {
                    pen.Color = Color.FromArgb(drawnFigure[1]);
                    pen.Width = drawnFigure[2];

                    g.DrawEllipse(pen, drawnFigure[3], drawnFigure[4], drawnFigure[5], drawnFigure[6]);
                }
            }

            //Получаем настройки кисти из панели инструментов.
            pen.Color = labelColorImage.BackColor;
            pen.Width = (float)numericUpDownWidth.Value;

            //Если мы рисуем во время перерисовки холста.
            if (isMouseButtonPressed)
            {
                if (figure == DrawStraightLine)
                {
                    g.DrawLine(pen, pointStart, pointCurrent);
                }

                else if (figure == DrawRectangle)
                {
                    g.DrawRectangle(pen, x, y, xDifference, yDifference);
                }

                else if (figure == DrawEllipse)
                {
                    g.DrawEllipse(pen, x, y, xDifference, yDifference);
                }
            }
        }

        /// <summary>
        /// Если изменён размер формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            g.Dispose();

            g = panelPainting.CreateGraphics();
            DoubleBuffered = true; //Умен. мерцания.
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //Сглаживание.
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round; //Круглое завершение отрезков.

            Refresh(); //Перерисовка со сглаживанием.
        }

        /// <summary>
        /// Если меняем толщину.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (float)numericUpDownWidth.Value;
        }

        /// <summary>
        /// Если нажата кнопка "Сохранить".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<List<int>>));

                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    formatter.Serialize(fs, content);
                }
            }
        }

        /// <summary>
        /// Если нажата кнопка "Загрузить".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                content.Clear();

                XmlSerializer formatter = new XmlSerializer(typeof(List<List<int>>));

                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    content = (List<List<int>>)formatter.Deserialize(fs);
                }

                panelPainting.Refresh();
            }
        }
    }
}
