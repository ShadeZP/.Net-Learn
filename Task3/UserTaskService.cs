using System;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void AddTaskForUser(int userId, UserTask task)
        {
            var user = ValidateAndGetUser(userId);

            foreach (var t in user.Tasks)
            {
                if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                    throw new UserTaskAlreadyExistsException();
            }

            user.Tasks.Add(task);
        }

        private IUser ValidateAndGetUser(int userId)
        {
            if (userId < 0)
                throw new InvalidUserIdException();

            var user = _userDao.GetUser(userId);
            if (user == null)
                throw new UserNotFoundException();

            return user;
        }
    }
}