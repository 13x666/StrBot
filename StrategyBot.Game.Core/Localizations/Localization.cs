using System;
using System.Linq;
using StrategyBot.Game.Logic.Communications;

namespace StrategyBot.Game.Logic.Localizations
{
    public class Localization
    {
        private readonly Random _random;
        private readonly string[] _formats;

        public Localization(Random random, string[] formats)
        {
            _random = random;
            _formats = formats;
        }

        public Localization Format(params object[] args) =>
            new Localization(
                _random,
                _formats.Select(f => string.Format(f, args)).ToArray()
            );

        public string Value => _formats[_random.Next(0, _formats.Length - 1)];

        public bool MatchesMessage(IncomingMessage message)
        {
            return _formats.Any(f => f.Equals(message.Text));
        }
    }
}