using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using Newtonsoft.Json;

namespace DataAccess.JSON;
public class DataAccessor
{
    private readonly string dataPath;
    private readonly string memberFile;

    public Lazy<Task<List<Member>>> Members { get; private set; }

    public DataAccessor()
    {
        dataPath = AppContext.BaseDirectory + "\\Data\\";
        memberFile = "\\members.json";

        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }

        Members = new Lazy<Task<List<Member>>>(GetMember);
    }

    /// <summary>
    /// Deserializes and returns the members in the applications base directory from JSON.
    /// </summary>
    private async Task<List<Member>> GetMember()
    {
        // var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + "member.json";
        var path = dataPath + memberFile;

        if (!File.Exists(path))
        {
            File.Create(path);
        }

        string json;
        using (StreamReader r = new StreamReader(path))
        {
            json = await r.ReadToEndAsync();
        }

        var members = JsonConvert.DeserializeObject<List<Member>>(json);

        // example data which can be removed on release ._.
        if (members == null || members.Count == 0)
        {
            members = new List<Member>()
            {
                new()
                {
                    BirthDate = DateTime.Now,
                    Contribution = 5,
                    EmploymentType = EmploymentType.Student,
                    FirstName = "Test1First",
                    LastName = "Test1Last",
                    IBAN = "123123123",
                },
                new()
                {
                    BirthDate = DateTime.Now,
                    Contribution = 10,
                    EmploymentType = EmploymentType.FullTimeEmployee,
                    FirstName = "tEsT2First",
                    LastName = "tEsT2Last",
                    IBAN = "456456456",
                }
            };
        }

        return members;
    }

    /// <summary>
    /// Serializes the members to the applications base directory as JSON.
    /// </summary>
    public async void SetMembers(List<Member> members)
    {
        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }

        var json = JsonConvert.SerializeObject(members);

        await File.WriteAllTextAsync(dataPath + memberFile, json);
    }
}