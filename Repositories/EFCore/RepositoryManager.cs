using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IUserRepository> _userRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));  // Lazy Loading has
                                                                                             // been made to prevent the                                                                        // resource consumption
        }
        public IUserRepository User => _userRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
