using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaManager
{
    public partial class SearchResults : Form
    {
        public SearchResults(List<TMDBResult> results)
        {
            InitializeComponent();
            dataGridResults.DataSource = results;
        }
    }
}
