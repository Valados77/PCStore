using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PCStore_MVC.Data;

namespace TestUsers
{
	[ApplicationDbContextTests]
	public class ApplicationDbContextTests
	{
		private ApplicationDbContext _dbContext;

		[TestInitialize]
		public void TestInitialize()
		{
			_dbContext = new ApplicationDbContext(options => options.UseSqlServer("Server=.;Database=PCStoreDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"));
		}

		[TestMethod]
		public async Task TestIdentityUser()
		{
			var user = new IdentityUser
			{
				UserName = "testuser",
				Email = "testuser@example.com",
				PhoneNumber = "1234567890"
			};
			_dbContext.Users.Add(user);
			await _dbContext.SaveChangesAsync();
			var savedUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == "testuser");
			Assert.IsNotNull(savedUser);
			Assert.AreEqual("testuser", savedUser.UserName);
			Assert.AreEqual("testuser@example.com", savedUser.Email);
			Assert.AreEqual("1234567890", savedUser.PhoneNumber);
		}

		[TestCleanup]
		public void TestCleanup()
		{
			_dbContext.Database.EnsureDeleted();
			_dbContext.Dispose();
		}
	}
}