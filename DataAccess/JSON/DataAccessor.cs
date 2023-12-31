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
    private readonly string accountFile;
    private readonly string contributionScalingFile;

    public Lazy<Task<List<Member>>> Members { get; private set; }
    public Lazy<Task<Account>> Account { get; private set; }
    public Lazy<Task<ContributionScaling>> ContributionScale { get; private set; }

    public DataAccessor()
    {
        dataPath = AppContext.BaseDirectory + "\\Data\\";
        memberFile = "\\members.json";
        accountFile = "\\account.json";
        contributionScalingFile = "\\contributionScaling.json";

        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }

        Members = new Lazy<Task<List<Member>>>(GetMember);
        Account = new Lazy<Task<Account>>(GetAccount);
        ContributionScale = new Lazy<Task<ContributionScaling>>(GetContributionScale);
    }

    /// <summary>
    /// Deserializes and returns the members in the applications base directory from JSON.
    /// </summary>
    private async Task<List<Member>> GetMember()
    {
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
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    Contribution = 5,
                    EmploymentType = EmploymentType.Student,
                    FirstName = "Test1First",
                    LastName = "Test1Last",
                    IBAN = "123123123",
                },
                new()
                {
                    Id = Guid.NewGuid(),
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
    public async Task SetMembers(List<Member> members)
    {
        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }

        var json = JsonConvert.SerializeObject(members);

        await File.WriteAllTextAsync(dataPath + memberFile, json);
    }

    /// <summary>
    /// Deserializes and returns the account in the applications base directory from JSON.
    /// </summary>
    private async Task<Account> GetAccount()
    {
        var path = dataPath + accountFile;

        if (!File.Exists(path))
        {
            File.Create(path);
        }

        string json;
        using (StreamReader r = new StreamReader(path))
        {
            json = await r.ReadToEndAsync();
        }

        var account = JsonConvert.DeserializeObject<Account>(json);

        // example data which can be removed on release ._.
        if (account == null || !account.Entries.Any())
        {
            account = new Account()
            {
                Balance = 420,
                Entries = new List<Entry>()
                {
                    new()
                    {
                        TimeStamp = DateTime.Now,
                        Value = 69,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now.AddDays(-5),
                        Value = 666,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now.AddHours(-5),
                        Value = -25,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now,
                        Value = 69,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now.AddDays(-5),
                        Value = 666,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now.AddHours(-5),
                        Value = -25,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now,
                        Value = 69,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now.AddDays(-5),
                        Value = 666,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now.AddHours(-5),
                        Value = -25,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now,
                        Value = 69,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now.AddDays(-5),
                        Value = 666,
                    },
                    new()
                    {
                        TimeStamp = DateTime.Now.AddHours(-5),
                        Value = -25,
                    }
                }
            };
        }

        return account;
    }

    /// <summary>
    /// Serializes the account to the applications base directory as JSON.
    /// </summary>
    public async Task SetAccount(Account account)
    {
        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }

        var json = JsonConvert.SerializeObject(account);

        await File.WriteAllTextAsync(dataPath + accountFile, json);
    }

    /// <summary>
    /// Deserializes and returns the contribution scaling in the applications base directory from JSON.
    /// </summary>
    private async Task<ContributionScaling> GetContributionScale()
    {
        var path = dataPath + contributionScalingFile;

        if (!File.Exists(path))
        {
            File.Create(path);
        }

        string json;
        using (StreamReader r = new StreamReader(path))
        {
            json = await r.ReadToEndAsync();
        }

        var contributionScaling = JsonConvert.DeserializeObject<ContributionScaling>(json);

        // example data which can be removed on release ._.
        if (contributionScaling == null)
        {
            contributionScaling = new()
            {
                Items = new List<ContributionScaleItem>()
                {
                    new()
                    {
                        Employment = EmploymentType.Student,
                        MinAge = 12,
                        MaxAge = 29,
                        Contribution = 5,
                    },
                    new()
                    {
                        Employment = EmploymentType.FullTimeEmployee,
                        MinAge = 16,
                        MaxAge = 29,
                        Contribution = 10,
                    },
                    new()
                    {
                        Employment = EmploymentType.FullTimeEmployee,
                        MinAge = 30,
                        MaxAge = 999,
                        Contribution = 20,
                    },
                }
            };
        }

        return contributionScaling;
    }

    /// <summary>
    /// Serializes the contribution scaling to the applications base directory as JSON.
    /// </summary>
    public async Task SetContributionScaling(ContributionScaling contributionScaling)
    {
        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }

        var json = JsonConvert.SerializeObject(contributionScaling);

        await File.WriteAllTextAsync(dataPath + contributionScalingFile, json);
    }
}