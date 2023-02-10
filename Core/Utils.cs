using System.Windows.Forms;

namespace Tåg_project
{
    public static class Utils
    {
        public static void OpenChildForm(Form childForm, Control parentForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            parentForm.Controls.Add(childForm);
            parentForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}