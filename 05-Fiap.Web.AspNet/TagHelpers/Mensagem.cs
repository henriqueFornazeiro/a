﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _05_Fiap.Web.AspNet.TagHelpers
{
    public class Mensagem:TagHelper
    {
        public string Texto { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if (!string.IsNullOrEmpty(Texto))
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "alert alert-success");
                output.Content.SetContent(Texto);
            }

        }

    }
}
