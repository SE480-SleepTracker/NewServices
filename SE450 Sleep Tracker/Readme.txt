HOW TO CALL
- Fiddler2
- OData controllers (which are sometimes a little weird in their behavior) are called from http://localhost:{portnumber}/odata/{controller}/{parameter}
The {parameter} is optional. The controller name is case sensitive. The OData version always end with "ModelsController"; the other controllers are non-OData. Do not include the
"Controller" suffix on the end of the URL. For example, http://localhost:2376/odata/CaffeineLogModels/1 would be a "get" request for the Caffeine Log with an identity of 1.
- The regular API controllers have the same calling convention, but replace "odata" with "api".
- Bodies of the regular requests are just standard JSON.

GENERAL NOTES
- The OData models have detailed comments in them. This can be helpful for understanding the database.
- There are also UML diagrams of the database attached. Not every field is shown; these are more to show the relationship between tables.
- The data layer library is largely "dead" at this point. At one point, I was manually implementing each controller and calling LINQ to SQL; however, I changed my mind on this.
- GitHub repository: https://github.com/SE480-SleepTracker/NewServices

LESSONS LEARNED
- Start with Entity Framework to begin with. I thought that LINQ to SQL would be easier but it ended up forcing me to do much more manual implementation. Entity Framework would've allowed
much more of the code to have been automatically generated so that I could've focused on the analytics engine.
- General lesson from above: where possible, allow tools to generate as much "boilerplate" code as possible so I can focus on the "interesting" logic.
- It was easier to use the automatically generated Entity Framework models than to use my own manually-implemented ones.

There are probably better ways of doing the mapping than what I was doing but it probably wasn't worthwhile in the context of this project.
- The complexity of using Web API was much more a function of me being unfamiliar with the technology and tools than the acutual implementation. In retrospect I wish I had had time to
read much more tutorials (or even a complete book) on the topic before starting to use it; it would have prevented a lot of mistakes and saved me time.
- One of the early complexities was understanding the authentication and user accounts models.
- Earlier completion of XML documentation would have been very useful since several group members were unfamiliar with Web API.