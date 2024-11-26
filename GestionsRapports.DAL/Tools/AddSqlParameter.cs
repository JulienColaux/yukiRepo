using System;
using System.Data.Common;

namespace Connectopia_DAL.Tools;

public static class AddSqlParameter
{
  public static void AddParamWithValue(this DbCommand cmd, string paramName, Object? value)
  {
    // Création d'un objet param
    DbParameter param = cmd.CreateParameter();
    param.ParameterName = paramName;
    // On vérifie si la valeur reçue est null afin d'insérer le NULL de DB dans ce cas
    param.Value = value ?? DBNull.Value;
    //param.Value = (value is null) ? DBNull.Value : value;
    cmd.Parameters.Add(param);
  }
}
