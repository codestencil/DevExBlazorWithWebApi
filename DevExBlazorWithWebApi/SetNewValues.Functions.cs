using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.DevExBlazorWithWebApi
{
    public partial class SetNewValues : ExpansionBase
    {

        private string _table;
        private void MainFunction()
        {
            _table = GetTable(GetTableName(Input));
            Output = Populate();
        }

        private string Populate()
        {
            var indent = 4;
            BuildSnippet(null);
            BuildSnippet("private void SetNewValues("+_table+" dataItem, Dictionary<string, object> newValues)",indent);
            BuildSnippet("{",indent);
            BuildSnippet("foreach (var field in newValues.Keys)",indent*2);
            BuildSnippet("{",indent*2);
            BuildSnippet("switch (field)",indent*3);
            BuildSnippet("{",indent*3);
            var columns = GetColumns(_table);
            foreach (var column in columns)
            {
                if (!column.IsPrimaryKey)
                {
                    var newValue = "("+column.ColumnType+")newValues[field]";
                    //switch (column.ColumnType)
                    //{
                    //    case "int":
                    //        newValue = "(int) newValues[field]"; break;
                    //    case "short":
                    //        newValue = "(short) newValues[field]"; break;
                    //}
                    BuildSnippet("case nameof("+_table+"."+column.ColumnName+"):",indent*4);
                    BuildSnippet("dataItem."+column.ColumnName+" = "+newValue+";",indent*5);
                    BuildSnippet("break;",indent*5);
                }
            }
            BuildSnippet("}",indent*3);
            BuildSnippet("}",indent*2);
            BuildSnippet("}",indent);
            BuildSnippet("");
            return BuildSnippet();
        }

        /// <summary>
        /// Reconstructs table name
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string GetTableName(string text)
        {
            var tableName = text.ToLower().Singularize();
            var table = SchemaItem
                .Select(x => x.TableName).FirstOrDefault(x => x.ToLower() == tableName);
            return table;
        }

    }
}


