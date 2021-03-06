//-----------------------------------------------------------------------
// <copyright file="SwaggerToTypeScriptClientGeneratorSettings.cs" company="NSwag">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/NSwag/NSwag/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System;
using NJsonSchema.CodeGeneration;
using NJsonSchema.CodeGeneration.TypeScript;
using NSwag.CodeGeneration.CodeGenerators.TypeScript.Templates;

namespace NSwag.CodeGeneration.CodeGenerators.TypeScript
{
    /// <summary>Settings for the <see cref="SwaggerToTypeScriptClientGenerator"/>.</summary>
    public class SwaggerToTypeScriptClientGeneratorSettings : ClientGeneratorBaseSettings
    {
        /// <summary>Initializes a new instance of the <see cref="SwaggerToTypeScriptClientGeneratorSettings"/> class.</summary>
        public SwaggerToTypeScriptClientGeneratorSettings()
        {
            ModuleName = "";
            ClassName = "{controller}Client";
            Template = TypeScriptTemplate.JQueryCallbacks;
            PromiseType = PromiseType.Promise;
            TypeScriptGeneratorSettings = new TypeScriptGeneratorSettings();
        }

        /// <summary>Gets or sets the TypeScript generator settings.</summary>
        public TypeScriptGeneratorSettings TypeScriptGeneratorSettings { get; set; }

        /// <summary>Gets or sets the output template.</summary>
        public TypeScriptTemplate Template { get; set; }

        /// <summary>Gets or sets the promise type.</summary>
        public PromiseType PromiseType { get; set; }

        /// <summary>Gets or sets the TypeScript module name (default: '', no module).</summary>
        public string ModuleName { get; set; }

        internal ITemplate CreateTemplate()
        {
            if (Template == TypeScriptTemplate.Angular2)
                return new Angular2Template();

            if (Template == TypeScriptTemplate.AngularJS)
                return new AngularJSTemplate();

            if (Template == TypeScriptTemplate.JQueryCallbacks)
                return new JQueryCallbacksTemplate();

            if (Template == TypeScriptTemplate.JQueryPromises)
                return new JQueryPromisesTemplate();

            throw new NotImplementedException();
        }
    }
}