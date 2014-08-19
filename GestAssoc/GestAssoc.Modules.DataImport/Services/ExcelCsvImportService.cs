using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.ImportModel;
using GestAssoc.Modules.DataImport.Util;
using LinqToExcel;
using System.Collections.Generic;
using System.Linq;

namespace GestAssoc.Modules.DataImport.Services
{
	public class ExcelCsvImportService : IExcelCsvImportService
	{
		public IEnumerable<ImportAdherent> ReadAdherents(string filePath, string sheetName, List<ColumnMapping> colMapping) {
			var excel = new ExcelQueryFactory(filePath);

			excel.AddMapping<ImportAdherent>(x => x.Nom, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Nom).ColumnHeader);
			excel.AddMapping<ImportAdherent>(x => x.Prenom, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Prenom).ColumnHeader);
			excel.AddMapping<ImportAdherent>(x => x.DateNaissance, colMapping.FirstOrDefault(y => y.DataName == ColumnName.DateNaissance).ColumnHeader);

			var ws = excel.Worksheet<ImportAdherent>(sheetName);

			return new List<ImportAdherent>(ws.ToList());
		}

		public IEnumerable<ColumnMapping> InitColMapping() {
			return new List<ColumnMapping> 
			{
				new ColumnMapping(ColumnName.Nom, string.Empty),
				new ColumnMapping(ColumnName.Prenom, string.Empty),
				new ColumnMapping(ColumnName.DateNaissance, string.Empty),
				new ColumnMapping(ColumnName.Adresse, string.Empty),
				new ColumnMapping(ColumnName.CodePostal, string.Empty),
				new ColumnMapping(ColumnName.Ville, string.Empty),
				new ColumnMapping(ColumnName.Tel1, string.Empty),
				new ColumnMapping(ColumnName.Tel2, string.Empty),
				new ColumnMapping(ColumnName.Tel3, string.Empty),
				new ColumnMapping(ColumnName.Mail1, string.Empty),
				new ColumnMapping(ColumnName.Mail2, string.Empty),
				new ColumnMapping(ColumnName.Mail3, string.Empty)
			};
		}


		public IEnumerable<string> GetSheetNames(string filePath) {
			var excel = new ExcelQueryFactory(filePath);
			return excel.GetWorksheetNames();
		}

		public IEnumerable<string> GetColumnsNames(string filePath, string worksheetName) {
			var excel = new ExcelQueryFactory(filePath);
			return excel.GetColumnNames(worksheetName);
		}
	}
}
