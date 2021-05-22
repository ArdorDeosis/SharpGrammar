using SharpGrammar;
using SharpGrammar.API;

namespace DwarfNameGenerator
{
    public static class DwarfNameGrammar
    {
        public static Processable DwarfName => Rule.OneOf(
            (2, DwarfNameStartEndingClosed + DwarfNameEnd),
            (2, DwarfNameStart + DwarfNameEndStartingWithConsonant),
            DwarfNameStart + DwarfNameMiddle + DwarfNameEndStartingWithConsonant
        );

        private static Processable DwarfNameStart => Rule.OneOf(
            (4, DwarfNameStartEndingClosed),
            DwarfNameStartEndingOpen
        );

        private static readonly Processable DwarfNameStartEndingClosed = Rule.OneOf("Alf", "Ar", "Arn",
            "As", "Bein", "Berg", "Bjar", "Björ", "Bor", "Dag", "Dan", "Dar", "Dor", "Dof", "Duf", "Dur",
            "Ed", "Eb", "Ein", "Eir", "Eng", "Es", "Ev", "Falk", "Fan", "Fang",
            "Far", "Fen", "Fer", "Fin", "Finn", "Fir", "Frid", "Fjar", "Fjör", "For",
            "Forn", "Frang", "Gab", "Gad", "Gam", "Gan", "Gar", "Gaur", "Gaut", "Geir", "Geg", "Geit",
            "Gerd", "Ges", "Gis", "Gim", "Gjaf", "Gjar", "Gjöf", "Gjor", "Got", "Grim",
            "Gud", "Gun", "Gunn", "Gus", "Had", "Haf", "Hag", "Ind", "Indr", "Ing", "Ir",
            "Ing", "Is", "Iv", "Jon", "Juf", "Jur", "Jör", "Jöd", "Jöf", "Jör", "Jös", "Jöt", "Jag",
            "Jak", "Jar", "Jarn", "Jat", "Jen", "Kad", "Kar", "Ket", "Kjar", "Kod",
            "Lif", "Leik", "Lot", "Lof", "Log", "Lor", "Lud", "Lyd", "Lyt", "Lyng", "Mag", "Mak", "Man", "Mar",
            "Mir", "Mod", "Mor", "Mos", "Mug", "Mun", "Mör", "Myr", "Nad", "Nar", "Naf", "Nat",
            "Njör", "Nor", "Ob", "Odd", "Rad", "Raf", "Rag", "Rak", "Ran", "Reid", "Reif", "Rein", "Reyn", "Rik",
            "Rud", "Rön", "Röd", "Sam", "San", "Sig", "Sjaf", "Than", "Thor",
            "Tyr", "Tryg", "Ugg", "Udd", "Ulf", "Un", "Ur", "Vag", "Vak", "Ver", "Vet", "Vid", "Vig",
            "Vik", "Vin", "Vir", "Vör", "Vöt", "Yg", "Yd", "Yn", "Yr");

        private static readonly Processable DwarfNameStartEndingOpen = Rule.OneOf("Bau", "Be", "Bre", "Bri", "Bru",
            "Bry", "Brö", "Bu", "Bae", "Bö", "Da", "De", "Du", "Dwo", "Dwa", "E", "Eo", "Ey", "Fa", "Fa", "Fi", "Flo",
            "Fro", "Fra", "Frey", "Glo", "Glu", "Gloi", "Gra", "Gre", "Gri", "Gy", "Ha", "Ingi", "Ja", "Jo", "Ju", "Jö",
            "Kjo", "Kle", "Kly", "Klae", "Knu", "Knö", "Rey", "Theo", "Ti", "To", "Trau", "Tru", "Va", "Yr",
            "Al", "Bal", "Dal", "El", "Erl", "Eorl", "Eyl", "Fal", "Fjal", "Fjol", "Fjöl", "Fol", "Gal", "Gael", "Gel",
            "Gil", "Gjal", "Gjöl", "Hafl", "Hal", "Hall", "Il", "Jol", "Jul", "Jarl", "Kal", "Kil", "Kjal", "Kol",
            "Mal", "Mjöl", "Mjol", "Mul", "Pal", "Sal", "Tafl", "Tofl", "Tjal", "Tjöl", "Ul", "Val", "Vil", "Völ",
            "Yl");

        private static readonly Processable DwarfNameMiddle  = Rule.OneOf("gri", "ra", "ri", "na", "kja", "ja", "bor", "bran", "bjar",
                "grim", "mun", "var", "dal", "del", "dil", "svin");

        private static Processable DwarfNameEnd => Rule.OneOf(
            DwarfNameEndStartingWithConsonant,
            DwarfNameEndStartingWithVowel);

        private static readonly Processable DwarfNameEndStartingWithConsonant = Rule.OneOf("bert", "berk", "bergr",
            "gar", "dur", "geir", "mur", "kur", "stein", "steinr", "rin", "ring", "nur", "gust", "gustr", "mir", "vil",
            "thur", "thor", "fur", "hard", "hart", "rir", "ling", "lir", "gan", "gand", "gandr", "mel", "nar", "nir",
            "dalf", "fir", "grim", "loin", "lori");

        private static readonly Processable DwarfNameEndStartingWithVowel =
            Rule.OneOf("olf", "an", "ulf", "aldi", "ori");
    }
}