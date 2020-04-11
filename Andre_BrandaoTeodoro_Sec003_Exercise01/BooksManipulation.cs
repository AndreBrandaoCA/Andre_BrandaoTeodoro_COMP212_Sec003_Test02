using BooksDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andre_BrandaoTeodoro_Sec003_Exercise01
{
    public partial class BooksManipulation : Form
    {
        public BooksManipulation()
        {
            InitializeComponent();
        }
        private BooksDb.BooksEntities dbContext = new BooksDb.BooksEntities();

        private void BooksManipulation_Load(object sender, EventArgs e)
        {
            queryComboBox.SelectedIndex = 0;
        }
        
        private void queryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear result textbox for the next query
            resultTextBox.Clear();
            #region Author Count
            // First Query: Get count of author by title, sorted by title.
            if (queryComboBox.SelectedIndex == 0)
            {
                //define query for books and authors ordered by title
                var authorCountByTitle =
                    from book in dbContext.Titles
                    orderby book.Title1
                    select new
                    {
                        Title = book.Title1,
                        AuthorCount =
                            from author in book.Authors
                            orderby author.LastName, author.FirstName
                            select author.FirstName
                    };
                // header
                resultTextBox.AppendText($"{"Title",-120} {"Number of Authors",-20}");
                // loop to display all titles and authors
                foreach (var book in authorCountByTitle)
                {
                    resultTextBox.AppendText($"\r\n{book.Title,-120} {book.AuthorCount.Count(),-20}");
                }
            }
            #endregion
            #region Title
            // Second Query: Get titles grouped by authors name
            if (queryComboBox.SelectedIndex == 1)
            {
                //define query for authors and its books
                var titleByAuthor =
                    from author in dbContext.Authors
                    orderby author.LastName, author.FirstName
                    select new
                    {
                        AuthorLN = author.LastName,
                        AuthorFN = author.FirstName,
                        Titles =
                            from Title in author.Titles
                            orderby Title.Title1
                            select Title.Title1
                    };
                // header for the GUI
                resultTextBox.AppendText($"{"Author and its titles:"}\r\n");
                // loop to display all authors and its
                foreach (var author in titleByAuthor)
                {
                    resultTextBox.AppendText($"\r\n{author.AuthorLN}, {author.AuthorFN}");
                    foreach (var book in author.Titles) {
                        resultTextBox.AppendText($"\r\n\t{book,-20}");
                    }
                }
            }
            #endregion
        }

    }
}
