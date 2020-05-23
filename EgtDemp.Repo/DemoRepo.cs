using EgtDemp.IRepo;
using EgtDemp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgtDemp.Repo
{
    public class DemoRepo : IDemoRepo
    {
        public List<Demo> GetDemos()
        {
            return new List<Demo>() {
                new Demo(){
                    Id=1,
                    Name="测试0001"
                },
                new Demo(){
                      Id=2,
                    Name="测试0002"
                }
            };
        }
    }
}
