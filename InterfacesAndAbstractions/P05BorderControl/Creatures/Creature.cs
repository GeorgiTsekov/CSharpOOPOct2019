namespace P05BorderControl.Creatures
{
    using P05BorderControl.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Creature : IIdNumber
    {
        private List<string> ids;
        private List<string> dates;

        public Creature()
        {
            this.ids = new List<string>();
            this.dates = new List<string>();
        }

        public string IdNumber { get; private set; }

        public void AddId(string id)
        {
            this.ids.Add(id);
        }

        public string ISLastDigitsOfIdsEquall(string lastDigits)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var id in this.ids)
            {
                int count = 0;

                for (int i = lastDigits.Length - 1; i >= 0; i--)
                {
                    if (id[id.Length - count - 1] != lastDigits[i])
                    {
                        count = 0;
                        break;
                    }

                    count++;
                }

                if (count != 0)
                {
                    sb.AppendLine(id);
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string ISLastDigitsOfDate(string lastDigits)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var date in this.dates)
            {
                int count = 0;

                for (int i = lastDigits.Length - 1; i >= 0; i--)
                {
                    if (date[date.Length - count - 1] != lastDigits[i])
                    {
                        count = 0;
                        break;
                    }

                    count++;
                }

                if (count != 0)
                {
                    sb.AppendLine(date);
                }
            }

            return sb.ToString().TrimEnd();
        }

        internal void AddDate(string date)
        {
            this.dates.Add(date);
        }
    }
}
