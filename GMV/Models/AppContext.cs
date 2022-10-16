using Microsoft.EntityFrameworkCore;

namespace GMV.Models
{
    public class AppContext : DbContext 
    {
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Stop>()
                .HasMany(b => b.Schedules)
                .WithOne();
            
            modelBuilder.Entity<Stop>().HasData(
                // Southbound Stops
                new Stop { Id = 6041, Name = "Beaudry Ave & 3rd St"},
                new Stop { Id = 6138, Name = "4th St & Figueroa St"},
                new Stop { Id = 6021, Name = "Flower St & 5th St"},
                new Stop { Id = 6139, Name = "Flower St & 7th St"},
                new Stop { Id = 6140, Name = "Flower St & 8th St"},
                new Stop { Id = 9638, Name = "Flower St & 9th St"},
                new Stop { Id = 6142, Name = "Flower St & Olympic Blvd"},
                new Stop { Id = 6143, Name = "LA Live"},
                new Stop { Id = 6144, Name = "Figueroa St & Pico Blvd"},
                new Stop { Id = 6145, Name = "Figueroa St & Venice Blvd"},
                new Stop { Id = 6146, Name = "Figueroa St & Washington Blvd"},
                new Stop { Id = 6147, Name = "Figueroa St & 23rd St"},
                new Stop { Id = 6148, Name = "Figueroa St & Adams Blvd"},
                new Stop { Id = 6149, Name = "Figueroa St & 30th St"},
                new Stop { Id = 6150, Name = "Figueroa St & Jefferson Blvd"},
                new Stop { Id = 6151, Name = "Figueroa St & McCarthy Way"},
                new Stop { Id = 6216, Name = "Exposition Blvd & Trousdale Pkwy"},
                new Stop { Id = 6152, Name = "Exposition Blvd & Watt Way"},
                // Northbound Stops
                new Stop { Id = 6040, Name = "Vermont Ave & Exposition Blvd"},
                new Stop { Id = 6119, Name = "Vermont Ave & 37th Pl"},
                new Stop { Id = 6120, Name = "Vermont Ave & 36th Pl"},
                new Stop { Id = 6121, Name = "Jefferson Blvd & Vermont Ave"},
                new Stop { Id = 6122, Name = "Jefferson Blvd & McClintock Ave"},
                new Stop { Id = 6123, Name = "Jefferson Blvd & Hoover St"},
                new Stop { Id = 6124, Name = "Figueroa St & 33rd St"},
                new Stop { Id = 6125, Name = "Figueroa St & 30th St"},
                new Stop { Id = 6126, Name = "Figueroa St & Adams Blvd"},
                new Stop { Id = 6127, Name = "Figueroa St & 23rd St"},
                new Stop { Id = 6128, Name = "Figueroa St & Washington Blvd"},
                new Stop { Id = 6129, Name = "Figueroa St & Venice Blvd"},
                new Stop { Id = 6130, Name = "Figueroa St & 12th St"},
                new Stop { Id = 6132, Name = "LA Live"},
                new Stop { Id = 6133, Name = "Figueroa St & Olympic Blvd"},
                new Stop { Id = 6135, Name = "Figueroa St & 8th St"},
                new Stop { Id = 6136, Name = "Figueroa St & 7th St"},
                new Stop { Id = 6137, Name = "Figueroa St & 5th St"}
                
            );
            
            // Add Schedule Data
            modelBuilder.Entity<Schedule>().HasData(
                // Southbound Schedule Set 1
                new Schedule { Id = 1, StopId = 6041, Time = 900},
                new Schedule { Id = 2, StopId = 6138, Time = 910},
                new Schedule { Id = 3, StopId = 6021, Time = 920},
                new Schedule { Id = 4, StopId = 6139, Time = 930},
                new Schedule { Id = 5, StopId = 6140, Time = 940},
                new Schedule { Id = 6, StopId = 9638, Time = 950},
                new Schedule { Id = 7, StopId = 6142, Time = 1000},
                new Schedule { Id = 8, StopId = 6143, Time = 1010},
                new Schedule { Id = 9, StopId = 6144, Time = 1020},
                new Schedule { Id = 10, StopId = 6145, Time = 1030},
                new Schedule { Id = 11, StopId = 6146, Time = 1040},
                new Schedule { Id = 12, StopId = 6147, Time = 1050},
                new Schedule { Id = 13, StopId = 6148, Time = 1100},
                new Schedule { Id = 14, StopId = 6149, Time = 1110},
                new Schedule { Id = 15, StopId = 6150, Time = 1120},
                new Schedule { Id = 16, StopId = 6151, Time = 1130},
                new Schedule { Id = 17, StopId = 6216, Time = 1140},
                new Schedule { Id = 18, StopId = 6152, Time = 1150},
                // Northbound Schedule Set 1
                new Schedule { Id = 19, StopId = 6040, Time = 1200},
                new Schedule { Id = 20, StopId = 6119, Time = 1210},
                new Schedule { Id = 21, StopId = 6120, Time = 1220},
                new Schedule { Id = 22, StopId = 6121, Time = 1230},
                new Schedule { Id = 23, StopId = 6122, Time = 1240},
                new Schedule { Id = 24, StopId = 6123, Time = 1250},
                new Schedule { Id = 25, StopId = 6124, Time = 1300},
                new Schedule { Id = 26, StopId = 6125, Time = 1310},
                new Schedule { Id = 27, StopId = 6126, Time = 1320},
                new Schedule { Id = 28, StopId = 6127, Time = 1330},
                new Schedule { Id = 29, StopId = 6128, Time = 1340},
                new Schedule { Id = 30, StopId = 6129, Time = 1350},
                new Schedule { Id = 31, StopId = 6130, Time = 1400},
                new Schedule { Id = 32, StopId = 6132, Time = 1410},
                new Schedule { Id = 33, StopId = 6133, Time = 1420},
                new Schedule { Id = 34, StopId = 6135, Time = 1430},
                new Schedule { Id = 35, StopId = 6136, Time = 1440},
                new Schedule { Id = 36, StopId = 6137, Time = 1450},
                // Southbound Schedule Set 2
                new Schedule { Id = 37, StopId = 6041, Time = 1500},
                new Schedule { Id = 38, StopId = 6138, Time = 1510},
                new Schedule { Id = 39, StopId = 6121, Time = 1520},
                new Schedule { Id = 40, StopId = 6139, Time = 1530},
                new Schedule { Id = 41, StopId = 6140, Time = 1540},
                new Schedule { Id = 42, StopId = 9638, Time = 1550},
                new Schedule { Id = 43, StopId = 6142, Time = 1600},
                new Schedule { Id = 44, StopId = 6143, Time = 1610},
                new Schedule { Id = 45, StopId = 6144, Time = 1620},
                new Schedule { Id = 46, StopId = 6145, Time = 1630},
                new Schedule { Id = 47, StopId = 6146, Time = 1640},
                new Schedule { Id = 48, StopId = 6147, Time = 1650},
                new Schedule { Id = 49, StopId = 6148, Time = 1700},
                new Schedule { Id = 50, StopId = 6149, Time = 1710},
                new Schedule { Id = 51, StopId = 6150, Time = 1720},
                new Schedule { Id = 52, StopId = 6151, Time = 1730},
                new Schedule { Id = 53, StopId = 6216, Time = 1740},
                new Schedule { Id = 54, StopId = 6152, Time = 1750},
                // Northbound Schedule Set 2
                new Schedule { Id = 55, StopId = 6040, Time = 1800},
                new Schedule { Id = 56, StopId = 6119, Time = 1810},
                new Schedule { Id = 57, StopId = 6120, Time = 1820},
                new Schedule { Id = 58, StopId = 6121, Time = 1830},
                new Schedule { Id = 59, StopId = 6122, Time = 1840},
                new Schedule { Id = 60, StopId = 6123, Time = 1850},
                new Schedule { Id = 61, StopId = 6124, Time = 1900},
                new Schedule { Id = 62, StopId = 6125, Time = 1910},
                new Schedule { Id = 63, StopId = 6126, Time = 1920},
                new Schedule { Id = 64, StopId = 6127, Time = 1930},
                new Schedule { Id = 65, StopId = 6128, Time = 1940},
                new Schedule { Id = 66, StopId = 6129, Time = 1950},
                new Schedule { Id = 67, StopId = 6130, Time = 2000},
                new Schedule { Id = 68, StopId = 6132, Time = 2010},
                new Schedule { Id = 69, StopId = 6133, Time = 2020},
                new Schedule { Id = 70, StopId = 6135, Time = 2030},
                new Schedule { Id = 71, StopId = 6136, Time = 2040},
                new Schedule { Id = 72, StopId = 6137, Time = 2050}
            );
            
        } 
    }
}