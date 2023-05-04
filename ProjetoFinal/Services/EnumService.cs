namespace ProjetoFinal.Services
{
    public static class EnumService
    {
        public static IList<SelectOption> GetOptions<T>()
        {
            var tipo = typeof(T);
            var result = Enum.GetNames(tipo).Select(
                item => new SelectOption
                {
                Value = Enum.Parse(tipo, item)
            }
                ).ToList();
            return result;
        }
    }
}
