using NGM.OpenAuthentication.Facebook.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace NGM.OpenAuthentication.Facebook {
    [OrchardFeature("Facebook")]
    public class FacebookConnectMigrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterPartDefinition(typeof(FacebookConnectSignInPart).Name, cfg => MetaDataExtensions.Attachable(cfg));

            ContentDefinitionManager.AlterTypeDefinition("FacebookConnectSignInWidget", cfg => cfg
                                                                                                   .WithPart("FacebookConnectSignInPart")
                                                                                                   .WithPart("WidgetPart")
                                                                                                   .WithPart("CommonPart")
                                                                                                   .WithSetting("Stereotype", "Widget"));

            return 1;
        }
    }
}