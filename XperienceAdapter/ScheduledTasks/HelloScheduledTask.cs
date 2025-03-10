using CMS.Core;
using CMS.Scheduler;

using XperienceAdapter.ScheduledTasks;

[assembly: RegisterScheduledTask(identifier: "Acme.HelloScheduledTask", typeof(HelloScheduledTask))]

namespace XperienceAdapter.ScheduledTasks;

public class HelloScheduledTask(IEventLogService eventLogService) : IScheduledTask
{
    // Called by the system when running the scheduled task.
    public async Task<ScheduledTaskExecutionResult> Execute(ScheduledTaskConfigurationInfo task, CancellationToken ct)
    {
        // Creates a record in the event log application

        for (var i = 0; i < 100; i++)
        {

            eventLogService.LogInformation("SCHEDULED_TASK", $"{i} NOTIFICATION {Environment.CurrentManagedThreadId} B", "Hello from my scheduled task!");

            await Task.Delay(10, ct);

            eventLogService.LogInformation("SCHEDULED_TASK", $"{i} NOTIFICATION {Environment.CurrentManagedThreadId} A", "Hello from my scheduled task!");
        }


        // Indicates successful task completion
        return new ScheduledTaskExecutionResult("Test result");
    }
}
