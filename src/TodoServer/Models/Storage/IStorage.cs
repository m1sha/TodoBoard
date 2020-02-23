using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoServer.Models.Storage
{
  public interface IStorage
  {
    void CheckConnection();
    void CreateIfNotExists();
  }
}
