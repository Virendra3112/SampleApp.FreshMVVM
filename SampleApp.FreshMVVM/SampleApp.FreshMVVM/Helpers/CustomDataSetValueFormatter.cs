using UltimateXF.Widget.Charts.Models.Formatters;

namespace SampleApp.FreshMVVM.Helpers
{
    public class CustomDataSetValueFormatter : IDataSetValueFormatter
    {
        public string GetFormattedValue(float value, int dataSetIndex)
        {
            return value.ToString("N2") + "$";
        }
    }
}
