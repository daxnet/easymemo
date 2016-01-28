using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMemo.Domain.Model;

namespace EasyMemo.Repositories
{
    public class DatabaseInitializeStrategy 
        : DropCreateDatabaseIfModelChanges<EasyMemoContext>
    {
        protected override void Seed(EasyMemoContext context)
        {
            var adminPermission = new Permission
            {
                Privilege = Privilege.SystemAdministration,
                Value = PermissionValue.Allow
            };

            var administrators = new Role
            {
                Name = "系统管理员",
                Description = "执行系统管理任务的一组账户",
                Permissions = new List<Permission> {adminPermission}
            };

            var administrator = new Account
            {
                DateCreated = DateTime.UtcNow,
                DisplayName = "管理员",
                Email = "admin@easymemo.com",
                Name = "admin",
                Password = "admin",
                Roles = new List<Role> {administrators}
            };

            context.Accounts.Add(administrator);

            base.Seed(context);
        }
    }
}
