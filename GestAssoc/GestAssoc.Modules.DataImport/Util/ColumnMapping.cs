using GestAssoc.Modules.DataImport.Constantes;

namespace GestAssoc.Modules.DataImport.Util
{
	public class ColumnMapping
	{
		public ColumnName DataName { get; set; }
		public string ColumnHeader { get; set; }

		public ColumnMapping(ColumnName dataName, string header) {
			this.DataName = dataName;
			this.ColumnHeader = header;
		}
	}
}
