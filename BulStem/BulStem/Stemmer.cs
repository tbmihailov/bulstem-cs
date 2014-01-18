using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BulStem
{
    public class Stemmer
    {
        public Hashtable stemmingRules = new Hashtable();
        public int STEM_BOUNDARY = 1;
        public static Regex vocals = new Regex("[^аъоуеияю]*[аъоуеияю]", RegexOptions.Compiled);
        public static Regex p = new Regex("([а-я-]+)\\s==>\\s([а-я]+)\\s([0-9]+)", RegexOptions.Compiled);

        StemmingLevel _level;
        public StemmingLevel Level
        {
            get { return _level; }
            private set { _level = value; }
        }

        public Stemmer(StemmingLevel level)
        {
            _level = level;
            LoadStemmingRules(level);
        }

        private void LoadStemmingRules(StemmingLevel level)
        {
            switch (level)
            {
                case StemmingLevel.Low:
                    LoadStemmingRules("BulStem.Rules.stem_rules_context_1_utf8.txt");
                    break;
                case StemmingLevel.Medium:
                    LoadStemmingRules("BulStem.Rules.stem_rules_context_2_utf8.txt");
                    break;
                case StemmingLevel.High:
                    LoadStemmingRules("BulStem.Rules.stem_rules_context_3_utf8.txt");
                    break;
                default:
                    break;
            }
        }

        private void LoadStemmingRules(String resourceName)
        {
            stemmingRules.Clear();
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream resTream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader br = new StreamReader(resTream, new UTF8Encoding(true, true)))
                {
                    String s = null;
                    while ((s = br.ReadLine()) != null)
                    {
                        Match m = p.Match(s);
                        if (m.Success)
                        {

                            int groupsCount = m.Groups.Count;
                            if (groupsCount == 4)
                            {
                                if (int.Parse(m.Groups[3].Value) > STEM_BOUNDARY)
                                {
                                    stemmingRules.Add(m.Groups[1].Value, m.Groups[2].Value);
                                }
                            }
                        }
                    }
                }
            }
        }

        public String Stem(String word)
        {
            string wordLowered = word.ToLower();
            Match m = vocals.Match(wordLowered, 0);
            if (!m.Success)
            {
                return wordLowered;
            }
            
            int matchEnd = m.Index+m.Captures[0].Value.Length;
            for (int i = matchEnd+1; i < wordLowered.Length; i++)
            {
                String suffix = wordLowered.Substring(i);

                string newSuffix = (String)stemmingRules[suffix];
                if (newSuffix != null)
                {
                    return wordLowered.Substring(0, i) + newSuffix;
                }
            }
            return wordLowered;
        }

    }

}
