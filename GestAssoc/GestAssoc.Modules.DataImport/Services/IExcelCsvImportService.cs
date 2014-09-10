using GestAssoc.Model.Models;
using GestAssoc.Modules.DataImport.ImportModel;
using GestAssoc.Modules.DataImport.Util;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.DataImport.Services
{
	public interface IExcelCsvImportService
	{
		IEnumerable<ImportLigne> ReadImportLignes(string filePath, string sheetName, List<ColumnMapping> colMapping);
		void InsertImportLignes(IEnumerable<ImportLigne> lignes);
		IEnumerable<ColumnMapping> InitColMapping(IEnumerable<string> columnsList);
		IEnumerable<string> GetSheetNames(string filePath);
		IEnumerable<string> GetColumnsNames(string filePath, string worksheetName);
	}
}
