using DAL;
using Microsoft.EntityFrameworkCore;

namespace Practico1 {
    public class StartUp {
        public void UpdateDatabase() {
            using var context = new DBContext();
            context.Database.Migrate();
        }
    }
}
