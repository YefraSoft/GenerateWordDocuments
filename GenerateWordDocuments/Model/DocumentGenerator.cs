using System;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace GenerateWordDocuments.Model
{
    public static class DocumentGenerator
    {
        public static bool Document(DateTime dateIncident, string teacherName,string teacherCode,string teacherMatter,int incidentType,string reazon)
        {
            Microsoft.Office.Interop.Word.Application app = new();
            Selection wrdSelection;
            Table table;
            _Document doc;
            Object oMissing = System.Reflection.Missing.Value;
            Object oFalse = false;
            //string imagePath = Path.GetFullPath("Resources\\Images\\footerBanner2.jpg");
            string imagePath = Path.GetFullPath("Resources\\Images\\footerBanner2.jpg");
            try
            {
                app.Visible = true;
                doc = app.Documents.Add();
                wrdSelection = app.Selection;
                doc.Select();

                //MARGIN
                PageSetup pageSetup = doc.PageSetup;
                pageSetup.LeftMargin = app.InchesToPoints(0.5f);
                pageSetup.RightMargin = app.InchesToPoints(0.5f);
                pageSetup.TopMargin = app.InchesToPoints(0.5f);
                pageSetup.BottomMargin = app.InchesToPoints(0.5f);

                //HEADER
                Section section = doc.Sections[1];
                Microsoft.Office.Interop.Word.Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                InlineShape headerImage = headerRange.InlineShapes.AddPicture(imagePath);
                headerImage.Height = 50;
                headerImage.Width = 545;

                //DOCUEMEMT
                wrdSelection.Font.Name = "Arial";
                wrdSelection.Font.Size = 12;
                wrdSelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                wrdSelection.TypeText("\nDia: " + DateTime.Now.Day + " Mes: " + DateTime.Now.Month + " Año: " + DateTime.Now.Year + "\n");
                wrdSelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                wrdSelection.TypeText("NOMBRE DEL RESPONSABLE DE RECURSOS HUMANOS DE LA UNIDAD\n");

                // TABLE
                table = doc.Tables.Add(wrdSelection.Range, 1, 1, ref oMissing, ref oMissing);
                table.Borders.Enable = 1;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth100pt;

                //TABLE CONTENT
                wrdSelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                wrdSelection.TypeText("\nColaborador: " + teacherName + "\nCódigo de Empleado: " + teacherCode + "\t Adscripción: " + teacherMatter + "\n");
                Object oConst1 = WdGoToItem.wdGoToLine;
                Object oConst2 = WdGoToDirection.wdGoToNext;
                app.Selection.GoTo(ref oConst1, ref oConst2, ref oMissing, ref oMissing);
                wrdSelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                wrdSelection.TypeText("TIPO DE INCIDENTE");

                // TABLE2
                table = doc.Tables.Add(wrdSelection.Range, 1, 1, ref oMissing, ref oMissing);
                table.Borders.Enable = 1;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth100pt;

                //TABLE2 CONTENT
                wrdSelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                switch (incidentType)
                {
                    case 1:
                        wrdSelection.TypeText("\nSalida Anticipada:");
                        wrdSelection.Font.Size = 14;
                        wrdSelection.TypeText(" X \t\t\t");
                        wrdSelection.Font.Size = 12;
                        wrdSelection.TypeText("Retardo:\n");
                        wrdSelection.TypeText("Omisión de entrada:\t\t\t\t");
                        wrdSelection.TypeText("Omisión de salida:\n\n");
                        break;
                    case 2:
                        wrdSelection.TypeText("\nSalida Anticipada:\t\t\t\t");
                        wrdSelection.TypeText("Retardo:");
                        wrdSelection.Font.Size = 14;
                        wrdSelection.TypeText(" X \n");
                        wrdSelection.Font.Size = 12;
                        wrdSelection.TypeText("Omisión de entrada:\t\t\t\t");
                        wrdSelection.TypeText("Omisión de salida:\n\n");
                        break;
                    case 3:
                        wrdSelection.TypeText("\nSalida Anticipada:\t\t\t\t");
                        wrdSelection.TypeText("Retardo:\n");
                        wrdSelection.TypeText("Omisión de entrada:");
                        wrdSelection.Font.Size = 14;
                        wrdSelection.TypeText(" X \t\t\t");
                        wrdSelection.Font.Size = 12;
                        wrdSelection.TypeText("Omisión de salida:\n\n");
                        break;
                    case 4:
                        wrdSelection.TypeText("\nSalida Anticipada:\t\t\t\t");
                        wrdSelection.TypeText("Retardo:\n");
                        wrdSelection.TypeText("Omisión de entrada:\t\t\t\t");
                        wrdSelection.TypeText("Omisión de salida:");
                        wrdSelection.Font.Size = 14;
                        wrdSelection.TypeText(" X \n\n");
                        wrdSelection.Font.Size = 12;
                        break;
                }
                wrdSelection.Font.Size = 12;
                wrdSelection.TypeText("Dia: " + dateIncident.Day + " Mes: " + dateIncident.Month + " Año: " + dateIncident.Year + "\n");
                wrdSelection.TypeText("Motivo:\n");

                //TABLE 3
                table = doc.Tables.Add(wrdSelection.Range, 1, 1, ref oMissing, ref oMissing);
                table.Borders.Enable = 1;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth100pt;

                //Table 3 CONTENT
                wrdSelection.TypeText(reazon);
                app.Selection.GoTo(ref oConst1, ref oConst2, ref oMissing, ref oMissing);

                //DOCUMENT Signature
                wrdSelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                wrdSelection.TypeText("\nSolicitante\t\t\t\t\t\t\t\t");
                wrdSelection.TypeText("Vo. Bo.\n");
                wrdSelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                wrdSelection.TypeText("Jefe (a) inmediato   \t\t\n\n");
                wrdSelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                wrdSelection.Font.Underline = WdUnderline.wdUnderlineSingle;
                wrdSelection.TypeText("______" + teacherName + "______");
                wrdSelection.Font.Underline = WdUnderline.wdUnderlineNone;
                wrdSelection.TypeText("\t\t____________________________________\n\n\n");
                wrdSelection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                wrdSelection.TypeText("Autorizo\n\n");
                wrdSelection.TypeText("____________________________________\n");
                wrdSelection.TypeText("DIRECTOR (A) DE UNIDAD ACADEMICA");
            }
            catch
            {
            }
            return true;
        }
    }
}
