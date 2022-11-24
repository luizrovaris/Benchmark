using BenchmarkDotNet.Attributes;
using Lists.Benchmark.Helper;

namespace Lists.Benchmark
{
    [MemoryDiagnoser]
    public class ListBenchmark
    {
        [Benchmark]
        public List<UserDTO> SearchObjectByCode()
        {
            var codes = DataHelper.Codes;

            List<UserDTO> users = new();
            for (int i = 0; i < codes.Count; i++)
            {
                UserDTO? user = DataHelper.Users
                    .FirstOrDefault(x => x.Code == i.ToString().PadLeft(3, '0'));

                if (user != null)
                {
                    users.Add(user);
                }
            }
            return users;
        }

        [Benchmark]
        public List<UserDTO> UseObjectItSelf()
        {
            List<UserDTO> users = new();
            for (int i = 0; i < DataHelper.Users.Count; i++)
            {
                UserDTO? user = DataHelper.Users
                    .FirstOrDefault(x => x.Code == i.ToString().PadLeft(3, '0'));
            }
            return users;
        }
    }
}
