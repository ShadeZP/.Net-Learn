using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                var task = new UserTask(description);
                _taskService.AddTaskForUser(userId, task);
                return true;
            }
            catch (InvalidUserIdException ex)
            {
                model.AddAttribute("action_result", ex.Message);
                return false;
            }
            catch (UserNotFoundException ex)
            {
                model.AddAttribute("action_result", ex.Message);
                return false;
            }
            catch (UserTaskAlreadyExistsException ex)
            {
                model.AddAttribute("action_result", ex.Message);
                return false;
            }
        }
    }
}