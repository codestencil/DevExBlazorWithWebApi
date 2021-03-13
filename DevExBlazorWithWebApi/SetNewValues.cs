using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.DevExBlazorWithWebApi
{
    /// <summary>
    /// </summary>
    [Export(typeof(ICodeStencilCodeNanite))]
    [CodeStencilCodeNanite(new[]
    {
        // 0 - Publisher: This is the name of the publisher
        "ZERA Systems Inc.",                    
        // 1 - Title: This is the title of the Code Nanite
        "DevExBlazorWithWebApi Stencil",    
        // 2 - Details: This is the description of the Code Nanite/Plugin
        "Code Nanite/Plugin for DevExBlazorWithWebApi Stencil",
        // 3 - Version Number
        "1.0",                                 
        // 4 - Label: Label of the Code Nanite
        "SetNewValues",                         
        // 5 - Namespace
        "ZeraSystems.DevExBlazorWithWebApi",  
        // 6 - Release Date
        "12-11-2020",                          
        // 7 - Name to use for Expander Label
        "CS_DXBLAZOR_SETNEWVALUES",                     
        // 8 - Indicates that the Nanite is Schema Dependent
        "0",                                   
        // 9 - RESERVED
        "",                                    
        // 10 - link to Online Help
        ""                                    
    })]
    public partial class SetNewValues : ExpansionBase, ICodeStencilCodeNanite
    { 
        public string Input { get; set; }
        public string Output { get; set; }
        public int Counter { get; set; }
        public List<string> OutputList { get; set; }
        public List<ISchemaItem> SchemaItem { get; set; }
        public List<IExpander> Expander { get; set; }
        public List<string> InputList { get; set; }

        public void ExecutePlugin()
        {
            Initializer(SchemaItem, Expander);
            MainFunction();
            //Output = ExpandedText.ToString();
        }

    }
}

