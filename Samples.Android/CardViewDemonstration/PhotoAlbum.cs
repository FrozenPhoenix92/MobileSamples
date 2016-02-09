using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Samples.Droid.CardViewDemonstration
{
    public class PhotoAlbum
    {
        private readonly Photo[] _photos = {
            new Photo { Id = Resource.Drawable.buckingham_guards,
                        Caption = "Buckingham Palace" },
            new Photo { Id = Resource.Drawable.la_tour_eiffel,
                        Caption = "The Eiffel Tower" },
            new Photo { Id = Resource.Drawable.louvre_1,
                        Caption = "The Louvre" },
            new Photo { Id = Resource.Drawable.before_mobile_phones,
                        Caption = "Before mobile phones" },
            new Photo { Id = Resource.Drawable.big_ben_1,
                        Caption = "Big Ben skyline" },
            new Photo { Id = Resource.Drawable.big_ben_2,
                        Caption = "Big Ben from below" },
            new Photo { Id = Resource.Drawable.london_eye,
                        Caption = "The London Eye" },
            new Photo { Id = Resource.Drawable.eurostar,
                        Caption = "Eurostar Train" },
            new Photo { Id = Resource.Drawable.arc_de_triomphe,
                        Caption = "Arc de Triomphe" },
            new Photo { Id = Resource.Drawable.louvre_2,
                        Caption = "Inside the Louvre" },
            new Photo { Id = Resource.Drawable.versailles_fountains,
                        Caption = "Versailles fountains" },
            new Photo { Id = Resource.Drawable.modest_accomodations,
                        Caption = "Modest accomodations" },
            new Photo { Id = Resource.Drawable.notre_dame,
                        Caption = "Notre Dame" },
            new Photo { Id = Resource.Drawable.inside_notre_dame,
                        Caption = "Inside Notre Dame" },
            new Photo { Id = Resource.Drawable.seine_river,
                        Caption = "The Seine" },
            new Photo { Id = Resource.Drawable.rue_cler,
                        Caption = "Rue Cler" },
            new Photo { Id = Resource.Drawable.champ_elysees,
                        Caption = "The Avenue des Champs-Elysees" },
            new Photo { Id = Resource.Drawable.seine_barge,
                        Caption = "Seine barge" },
            new Photo { Id = Resource.Drawable.versailles_gates,
                        Caption = "Gates of Versailles" },
            new Photo { Id = Resource.Drawable.edinburgh_castle_2,
                        Caption = "Edinburgh Castle" },
            new Photo { Id = Resource.Drawable.edinburgh_castle_1,
                        Caption = "Edinburgh Castle up close" },
            new Photo { Id = Resource.Drawable.old_meets_new,
                        Caption = "Old meets new" },
            new Photo { Id = Resource.Drawable.edinburgh_from_on_high,
                        Caption = "Edinburgh from on high" },
            new Photo { Id = Resource.Drawable.edinburgh_station,
                        Caption = "Edinburgh station" },
            new Photo { Id = Resource.Drawable.scott_monument,
                        Caption = "Scott Monument" },
            new Photo { Id = Resource.Drawable.view_from_holyrood_park,
                        Caption = "View from Holyrood Park" },
            new Photo { Id = Resource.Drawable.tower_of_london,
                        Caption = "Outside the Tower of London" },
            new Photo { Id = Resource.Drawable.tower_visitors,
                        Caption = "Tower of London visitors" },
            new Photo { Id = Resource.Drawable.one_o_clock_gun,
                        Caption = "One O'Clock Gun" },
            new Photo { Id = Resource.Drawable.victoria_albert,
                        Caption = "Victoria and Albert Museum" },
            new Photo { Id = Resource.Drawable.royal_mile,
                        Caption = "The Royal Mile" },
            new Photo { Id = Resource.Drawable.museum_and_castle,
                        Caption = "Edinburgh Museum and Castle" },
            new Photo { Id = Resource.Drawable.portcullis_gate,
                        Caption = "Portcullis Gate" },
            new Photo { Id = Resource.Drawable.to_notre_dame,
                        Caption = "Left or right?" },
            new Photo { Id = Resource.Drawable.pompidou_centre,
                        Caption = "Pompidou Centre" },
            new Photo { Id = Resource.Drawable.heres_lookin_at_ya,
                        Caption = "Here's Lookin' at Ya!" },
            };

        private readonly Random _random;

        public PhotoAlbum()
        {
            _random = new Random();
        }

        public int Count => _photos.Length;

        public Photo this[int index] => _photos[index];

        public int RandomSwap()
        {
            var firstPhoto = _photos[0];
            var random = _random.Next(1, _photos.Length);
            _photos[0] = _photos[random];
            _photos[random] = firstPhoto;
            return random;
        }

        public void Shuffle()
        {
            for (var index = 0; index < _photos.Length; index++)
            {
                var random = _random.Next(0, _photos.Length);
                var bufPhoto = _photos[index];
                _photos[index] = _photos[random];
                _photos[random] = bufPhoto;
            }
        }
    }
}