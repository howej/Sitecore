define(["sitecore", "/-/speak/v1/ExperienceEditor/ExperienceEditor.js", "/-/speak/v1/ExperienceEditor/ExperienceEditorProxy.js"], function (Sitecore, ExperienceEditor, ExperienceEditorProxy) {
    Sitecore.Commands.EditMetaTags =
        {
            commandContext: null,
            isEnabled: true,
            canExecute: function (context) {
                if (!ExperienceEditor.isInMode("edit") || !context || !context.button || context.currentContext.isFallback) {
                    return false;
                }

                return true;
            },
            execute: function (context) {
                ExperienceEditorProxy._pe().postRequest("webedit:fieldeditor(id=" + decodeURI(context.currentContext.itemId) + ",fields=MetaTitle|MetaKeywords|MetaDescription,command={C2332E33-EA84-44DB-A299-FE005BDE22A6})", null, false);
            }
        };
});