using HarmonyLib;
using System.Xml;
using Verse;

namespace IdeologyPatch
{
    public class PatchOperationAddIf : PatchOperationAdd
    {
        private XmlContainer setting;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            string settingText = setting.node.InnerText;
            return (bool)typeof(IdeologyPatchSettings).Field(settingText).GetValue(null) ? base.ApplyWorker(xml) : true;
        }
    }
}
