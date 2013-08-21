using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serializing3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*Shows how the code works
        public void RunExample()
        {
            Create objects First 

            //save objects
            FileSerializer.Serialize(@"Location such as: C:\Users\user\Documents\Mustaqeem\data.dat", variable name of object);

            //now read them back in
            object = FileSerializer.Deserialize<typeofObject>(@"location such as C:\Users\user\Documents\Mustaqeem\data.dat");
        }
         * */
    }
}
