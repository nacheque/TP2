namespace TP2
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtA.Enabled = false;
            txtB.Enabled = false;
            txtMedia.Enabled = false;
            txtDE.Enabled = false;
            btnGenerar.Enabled = false;
            

            List<string> list = new List<string> { "UNIFORME[a,b]", "Exponencial Negativa[me]", "NORMAL[me,de]" };
            cmbDistribucion.DataSource = list;
            cmbDistribucion.SelectedIndex = -1;

            

        }
        private void cmbDistribucion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDistribucion.SelectedIndex == 0)
            {

                txtA.Enabled = true;
                txtB.Enabled = true;
                btnGenerar.Enabled = true;
                txtMedia.Enabled = false;
                txtDE.Enabled = false;

            }
            else
            {
                if (cmbDistribucion.SelectedIndex == 1)
                {
                    txtMedia.Enabled = true;
                    txtA.Enabled = false;
                    txtB.Enabled = false;
                    txtDE.Enabled = false;
                    btnGenerar.Enabled = true;
                }
                else
                {
                    if (cmbDistribucion.SelectedIndex == 2)
                    {
                        txtMedia.Enabled = true;
                        txtDE.Enabled = true;
                        txtA.Enabled = false;
                        txtB.Enabled = false;
                        btnGenerar.Enabled = true;
                    }
                }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbDistribucion.SelectedIndex == 0)
            {
                if (txtA.Text != "" && txtB.Text != "" && txtTama�o.Text != "")
                {
                    if (int.Parse(txtA.Text.ToString()) > int.Parse(txtB.Text.ToString()))
                    {
                        MessageBox.Show("A no puede ser mayor que B");
                    }
                    else
                    {
                        double a = double.Parse(txtA.Text.ToString());
                        double b = double.Parse(txtB.Text.ToString());
                        int n = int.Parse(txtTama�o.Text.ToString());

                        Uniforme uniforme = new Uniforme(a,b,n);
                        uniforme.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese los paramteros para continuar...");
                }
            }
            else
            {
                if (cmbDistribucion.SelectedIndex == 1)
                {
                    if (int.Parse(txtMedia.Text.ToString()) < 0)
                    {
                        MessageBox.Show("La media no puede ser negativa");
                    }
                    else
                    {
                        double me = double.Parse(txtMedia.Text.ToString());
                        int n = int.Parse(txtTama�o.Text.ToString());

                        Exponencial exponencial = new Exponencial(me, n);
                        exponencial.Show();
                    }
                }
                else
                {
                    if (cmbDistribucion.SelectedIndex == 2)
                    {
                        
                        double me = double.Parse(txtMedia.Text.ToString());
                        double de = double.Parse(txtDE.Text.ToString());
                        int n = int.Parse(txtTama�o.Text.ToString());

                        Normal normal = new Normal(me, de, n);
                        normal.Show();

                    }
                }
            }

        }
    }
}
