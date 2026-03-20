using GC_Board_Game_Cats.Models;

namespace GC_Board_Game_Cats.Data
{
    public class SeedData
    {
        public static void Seed(AppDbContext context)
        {
            // Add users if they don't exist
            if (!context.AppUsers.Any(u => u.Username == "DaveGrohl"))
            {
                var user1 = new AppUser
                {
                    Username = "DaveGrohl",
                    Password = "fooFighters2000",
                    Email = "dave@foofighters.com"
                };

                var user2 = new AppUser
                {
                    Username = "EddieVedder",
                    Password = "pearlJam1990",
                    Email = "eddie@pearljam.com"
                };

                var user3 = new AppUser
                {
                    Username = "ThomYorke",
                    Password = "radiohead1997",
                    Email = "thom@radiohead.com"
                };

                context.AppUsers.AddRange(user1, user2, user3);
                context.SaveChanges();

                // Add blog posts
                var blogPosts = new List<BlogPost>
                {
                    new BlogPost
                    {
                        Title = "The Evolution of Grunge Rock",
                        Text = "Grunge changed everything in the 90s. From Seattle to the world, this movement brought raw emotion and authenticity to rock music. Bands like Nirvana, Pearl Jam, and Soundgarden defined a generation. The distorted guitars, angst-filled lyrics, and flannel shirts became the uniform of a generation seeking truth in music.",
                        AppUserId = user1.UserId,
                        DatePosted = new DateTime(2026, 3, 15, 10, 30, 0),
                        Rating = 5
                    },
                    new BlogPost
                    {
                        Title = "Why Pearl Jam Still Matters",
                        Text = "Twenty years later and Pearl Jam's music continues to inspire. Eddie Vedder's haunting vocals combined with Jeff Ament's bass lines created some of the most memorable rock songs of all time. Albums like 'Ten' and 'Vitalogy' are timeless masterpieces that capture the essence of 90s rock culture.",
                        AppUserId = user2.UserId,
                        DatePosted = new DateTime(2026, 3, 15, 14, 45, 0),
                        Rating = 5
                    },
                    new BlogPost
                    {
                        Title = "Radiohead's Experimental Journey",
                        Text = "Radiohead pushed the boundaries of rock music in ways nobody expected. Starting with 'The Bends' and evolving into the electronic masterpiece 'OK Computer', they showed that rock music didn't have to follow formula. Thom Yorke's unique vocal style paired with Jonny Greenwood's innovative guitar work created something truly revolutionary.",
                        AppUserId = user3.UserId,
                        DatePosted = new DateTime(2026, 3, 18, 9, 15, 0),
                        Rating = 4
                    },
                    new BlogPost
                    {
                        Title = "The Legacy of 90s Rock",
                        Text = "The 1990s and early 2000s gave us some of the greatest rock bands in history. From the heavy riffs of Stone Temple Pilots to the melodic genius of Foo Fighters, this era proved that rock music could be both commercially successful and artistically meaningful. These bands influenced countless musicians and continue to do so today.",
                        AppUserId = user1.UserId,
                        DatePosted = new DateTime(2026, 3, 18, 16, 20, 0),
                        Rating = 5
                    }
                };

                context.BlogPosts.AddRange(blogPosts);
                context.SaveChanges();
            }
        }
    }
}
