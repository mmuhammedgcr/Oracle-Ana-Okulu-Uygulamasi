using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace WpfApplication1
{
    class Export
    {



        //WORD İÇİN

        public static void Export_Data_To_Word(DataGridView DGV, string filename, string baslik)
        {
            String yaziRenk = "#000000";
            Form1 bas = new Form1();
            if (DGV.Rows.Count != 0)

            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorDarkRed;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                ////table style 
                //oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                //oDoc.Application.Selection.Tables[1].Rows[1].Select();
                //oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = baslik;
                    headerRange.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorBlack;
                    headerRange.Font.Size = 18;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save the file
                oDoc.SaveAs(filename);

                //NASSIM LOUCHANI
            }
        }

        internal static void toExcel(DataGridView dgvOgrenci, string fileName)
        {
            throw new NotImplementedException();
        }


        //    //Excel için

        //private void button_Click(object sender, EventArgs e)
        //{
        //}


        //    private static void releaseObject(object obj)
        //    {
        //        try
        //        {
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //            obj = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            obj = null;
        //            MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
        //        }
        //        finally
        //        {
        //            GC.Collect();
        //        }
        //    }

        //    public static void toExcel(DataGridView dgv, string filePath)
        //    {
        //        //Excel.Application xlApp;
        //        //Excel.Workbook xlWorkBook;
        //        //Excel.Worksheet xlWorkSheet;
        //        //object misValue = System.Reflection.Missing.Value;

        //        //xlApp = new Excel.Application();
        //        //xlWorkBook = xlApp.Workbooks.Add(misValue);
        //        //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        //        //int i = 0;
        //        //int j = 0;

        //        //for (i = 0; i <= dgv.RowCount - 1; i++)
        //        //{
        //        //    for (j = 0; j <= dgv.ColumnCount - 1; j++)
        //        //    {
        //        //        DataGridViewCell cell = dgv[j, i];
        //        //        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
        //        //    }
        //        //}



        //        //xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //        //xlWorkBook.Close(true, misValue, misValue);
        //        //xlApp.Quit();

        //        //releaseObject(xlWorkSheet);
        //        //releaseObject(xlWorkBook);
        //        //releaseObject(xlApp);

        //    }

        //    internal static void Export_Data_To_Word(DataGridView dgvOgrenci, string fileName)
        //    {
        //        throw new NotImplementedException();
    }
}

