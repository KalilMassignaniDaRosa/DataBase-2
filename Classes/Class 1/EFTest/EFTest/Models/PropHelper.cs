namespace EFTest.Models
{
    public static class PropHelper
    {
        // Busca propriedade no objeto
        public static string PropToString(object obj, params string[] possibleNames)
        {
            if (obj == null) 
                return "";

            var t = obj.GetType();
            foreach (var n in possibleNames)
            {
                var p = t.GetProperty(n);
                if (p != null)
                {
                    var v = p.GetValue(obj);
                    if (v != null) 
                        return v.ToString();
                }
            }
            return "";
        }

        // Busca propriedades em colecoes
        public static IEnumerable<object> PropToEnumerable(object obj, params string[] possibleNames)
        {
            if (obj == null) 
                return Enumerable.Empty<object>();

            var t = obj.GetType();
            foreach (var n in possibleNames)
            {
                var p = t.GetProperty(n);
                if (p != null)
                {
                    var v = p.GetValue(obj);

                    if (v is IEnumerable<object> eo) 
                        return eo;

                    if (v is System.Collections.IEnumerable ie)
                    {
                        var list = new List<object>();

                        foreach (var i in ie) 
                            list.Add(i);

                        return list;
                    }
                }
            }
            return Enumerable.Empty<object>();
        }
    }
}
