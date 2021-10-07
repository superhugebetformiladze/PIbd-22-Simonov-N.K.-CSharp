using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab1_TP_v2
{
    class Liner
    {
        /// <summary>
        /// Наличие капитанской рубки
        /// </summary>
        public bool CaptainsCabin { private set; get; }
        /// <summary>
        /// Наличие иллюминаторов
        /// </summary>
        public bool Window { private set; get; }
        /// <summary>
        /// Правая кооридната отрисовки
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Левая кооридната отрисовки
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight;
        /// <summary>
        /// Ширина отрисовки лайнера
        /// </summary>
        private readonly int LinerWidth = 240;
        /// <summary>
        /// Высота отрисовки лайнера
        /// </summary>
        private readonly int LinerHeight = 110;
        /// <summary>
        /// Максимальная скорость лайнера
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес лайнера
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет лайнера
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color SecondColor { private set; get; }
        public void Init(int maxSpeed, float weight, Color mainColor, Color secondColor,
            bool window, bool captainsCabin)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            SecondColor = secondColor;
            Window = window;
            CaptainsCabin = captainsCabin;

        }
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public void MoveLiner(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - LinerWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - LinerHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public void DrawLiner(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 2.0F;
            Brush brBlack = new SolidBrush(Color.Black);
            Brush brWindow = new SolidBrush(Color.FromArgb(179, 212, 222));
            Brush brMain = new SolidBrush(MainColor);
            Brush brSecond = new SolidBrush(SecondColor);

            // нижняя часть лайнера
            g.FillPolygon(brMain, new[]{
                    new Point(Convert.ToInt32(_startPosX), Convert.ToInt32(_startPosY + 60)),
                    new Point(Convert.ToInt32(_startPosX + 35), Convert.ToInt32(_startPosY + 110)),
                    new Point(Convert.ToInt32(_startPosX + 155), Convert.ToInt32(_startPosY + 110)),
                    new Point(Convert.ToInt32(_startPosX + 240), Convert.ToInt32(_startPosY + 60))
            });

            // середина лайнера
            RectangleF Body = new RectangleF(_startPosX + 20, _startPosY + 30, 150, 30);
            g.FillRectangle(brSecond, Body);

            // кабина капитана
            if (CaptainsCabin)
            {
                g.FillPolygon(brMain, new[]{
                    new Point(Convert.ToInt32(_startPosX + 30), Convert.ToInt32(_startPosY)),
                    new Point(Convert.ToInt32(_startPosX + 30), Convert.ToInt32(_startPosY + 30)),
                    new Point(Convert.ToInt32(_startPosX + 140), Convert.ToInt32(_startPosY + 30)),
                    new Point(Convert.ToInt32(_startPosX + 110), Convert.ToInt32(_startPosY)),
                    new Point(Convert.ToInt32(_startPosX + 30), Convert.ToInt32(_startPosY))
            });
            }

            // полоса на нижней части
            g.FillPolygon(brBlack, new[]{
                    new Point(Convert.ToInt32(_startPosX), Convert.ToInt32(_startPosY + 60)),
                    new Point(Convert.ToInt32(_startPosX + 3), Convert.ToInt32(_startPosY + 65)),
                    new Point(Convert.ToInt32(_startPosX + 232), Convert.ToInt32(_startPosY + 65)),
                    new Point(Convert.ToInt32(_startPosX + 240), Convert.ToInt32(_startPosY + 60))
            });

            // якорь
            g.DrawLine(pen, _startPosX + 180, _startPosY + 70, _startPosX + 180, _startPosY + 85);
            g.DrawLine(pen, _startPosX + 175, _startPosY + 82, _startPosX + 185, _startPosY + 82);
            g.DrawLine(pen, _startPosX + 177, _startPosY + 75, _startPosX + 183, _startPosY + 75);

            // иллюминаторы
            if (Window)
            {
                RectangleF Window = new RectangleF(_startPosX + 20, _startPosY + 35, 150, 20);
                g.FillRectangle(brWindow, Window);

                g.DrawLine(pen, _startPosX + 20, _startPosY + 35, _startPosX + 170, _startPosY + 35);
                g.DrawLine(pen, _startPosX + 20, _startPosY + 55, _startPosX + 170, _startPosY + 55);

                g.DrawLine(pen, _startPosX + 42, _startPosY + 55, _startPosX + 42, _startPosY + 35);
                g.DrawLine(pen, _startPosX + 62, _startPosY + 55, _startPosX + 62, _startPosY + 35);
                g.DrawLine(pen, _startPosX + 110, _startPosY + 55, _startPosX + 110, _startPosY + 35);
                g.DrawLine(pen, _startPosX + 130, _startPosY + 55, _startPosX + 130, _startPosY + 35);
                g.DrawLine(pen, _startPosX + 150, _startPosY + 55, _startPosX + 150, _startPosY + 35);

                g.DrawEllipse(pen, _startPosX + 70, _startPosY + 40, 10, 10);
                g.DrawEllipse(pen, _startPosX + 90, _startPosY + 40, 10, 10);
            }

            // обводка контуров
            g.DrawPolygon(pen, new[]{
                    new Point(Convert.ToInt32(_startPosX), Convert.ToInt32(_startPosY + 60)),
                    new Point(Convert.ToInt32(_startPosX + 35), Convert.ToInt32(_startPosY + 110)),
                    new Point(Convert.ToInt32(_startPosX + 155), Convert.ToInt32(_startPosY + 110)),
                    new Point(Convert.ToInt32(_startPosX + 240), Convert.ToInt32(_startPosY + 60)),
                    new Point(Convert.ToInt32(_startPosX + 170), Convert.ToInt32(_startPosY + 60)),
                    new Point(Convert.ToInt32(_startPosX + 170), Convert.ToInt32(_startPosY + 30)),
                    new Point(Convert.ToInt32(_startPosX + 140), Convert.ToInt32(_startPosY + 30)),
                    new Point(Convert.ToInt32(_startPosX + 110), Convert.ToInt32(_startPosY)),
                    new Point(Convert.ToInt32(_startPosX + 30), Convert.ToInt32(_startPosY)),
                    new Point(Convert.ToInt32(_startPosX + 30), Convert.ToInt32(_startPosY + 30)),
                    new Point(Convert.ToInt32(_startPosX + 20), Convert.ToInt32(_startPosY + 30)),
                    new Point(Convert.ToInt32(_startPosX + 20), Convert.ToInt32(_startPosY + 60)),
            });
            g.DrawLine(pen, _startPosX + 30, _startPosY + 30, _startPosX + 140, _startPosY + 30);
        }
    }
}