using System;
using System.Drawing;
using System.Windows.Forms;

namespace num_8_try_2
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Form form = new InteractiveForm("Интерактивная форма");
            Application.Run(form);
        }

        public class InteractiveForm : Form
        {
            private bool _mouseOnForm = false;
            private int titleHeight = 600;
            private int titleWidth = 800;
            private FormStartPosition startPosition = FormStartPosition.CenterScreen;

            public InteractiveForm(string title)
            {
                Text = title;
                Size = new Size(titleWidth, titleHeight);
                StartPosition = startPosition;
              
                BackColor = Color.LightGray;

                Button exitButton = CreateButton(new Size(60, 30), new Point(700, 500), "Выход");
                exitButton.Click += (sender, e) => Application.Exit();

                Label titleLabel = CreateLabel(new Size(150, 24), new Point(10, 0), "Светофор");
                titleLabel.Font = new Font(titleLabel.Font.FontFamily, 12f, FontStyle.Bold);

                RadioButton rbWhite = CreateRadioButton(new Size(150, 20), new Point(10, 30), "ЖДАТЬ");
                RadioButton rbGray = CreateRadioButton(new Size(150, 20), new Point(10, 70), "ПРИГОТОВИТЬСЯ");
                RadioButton rbBlue = CreateRadioButton(new Size(150, 20), new Point(10, 110), "МОЖНО ЕХАТЬ");

                rbWhite.CheckedChanged += (s, e) =>
                {
                    if (rbWhite.Checked) BackColor = Color.Red;
                };
                rbGray.CheckedChanged += (s, e) =>
                {
                    if (rbGray.Checked) BackColor = Color.Gold;
                };
                rbBlue.CheckedChanged += (s, e) =>
                {
                    if (rbBlue.Checked) BackColor = Color.Green;
                };

              
            }

            private void SetCommonParameters(Control element, Size size, Point position, string title)
            {
                element.Size = size;
                element.Location = position;
                element.Text = title;
                Controls.Add(element);
            }

            private Button CreateButton(Size size, Point position, string title)
            {
                Button button = new Button();
                SetCommonParameters(button, size, position, title);
                return button;
            }

            private Label CreateLabel(Size size, Point position, string title)
            {
                Label label = new Label();
                SetCommonParameters(label, size, position, title);
                return label;
            }

            private RadioButton CreateRadioButton(Size size, Point position, string title)
            {
                RadioButton radio = new RadioButton();
                SetCommonParameters(radio, size, position, title);
                return radio;
            }
        }
    }
}



