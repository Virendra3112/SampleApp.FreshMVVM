using SampleApp.FreshMVVM.Models.Enum;

namespace SampleApp.FreshMVVM.Models
{
    public class SettingsMenuItems
    {
        public int Id { get; set; }
        public SettingsMenuEnum MenuName { get; set; }
        public string CurrentMenuSetting { get; set; }
    }
}
