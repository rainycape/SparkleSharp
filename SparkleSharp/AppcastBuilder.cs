using System;
using System.Linq;
using System.Collections.Generic;
using Foundation;

namespace SparkleSharp
{

    public class AppcastItemBuilder : NSObject
    {
        private NSMutableDictionary _enclosure;
        private NSMutableArray _tags;
        private NSMutableDictionary _dictionary;

        AppcastItemBuilder()
        {
            _enclosure = new NSMutableDictionary();
            _tags = new NSMutableArray();
            _dictionary = new NSMutableDictionary();

            _dictionary.Add(FromObject("sparkle:tags"), _tags);
            _dictionary.Add(FromObject("enclosure"), _enclosure);

            _enclosure.Add(FromObject("type"), FromObject("application/octet-stream"));
        }

        public AppcastItemBuilder WithTitle(string title)
        {
            _dictionary.Add(FromObject("title"), FromObject(title));
            return this;
        }

        public AppcastItemBuilder WithDescription(string description)
        {
            _dictionary.Add(FromObject("description"), FromObject(description));
            return this;
        }

        public AppcastItemBuilder WithReleaseNoteUrl(string url)
        {
            _dictionary.Add(FromObject("sparkle:releaseNotesLink"), FromObject(url));
            return this;
        }

        public AppcastItemBuilder WithPublicationDate(NSDate date)
        {
            var formatter = new NSDateFormatter();
            formatter.DateFormat = "EEE, dd MMM yyyy HH:mm:ss ZZ";
            _dictionary.Add(FromObject("pubDate"), FromObject(formatter.ToString(date)));
            return this;
        }

        public AppcastItemBuilder WithMinSystemVersion(string version)
        {
            _dictionary.Add(FromObject("sparkle:minimumSystemVersion"), FromObject(version));
            return this;
        }

        public AppcastItemBuilder WithMaxSystemVersion(string version)
        {
            _dictionary.Add(FromObject("sparkle:minimumSystemVersion"), FromObject(version));
            return this;
        }

        public AppcastItemBuilder WithCriticalUpdate(bool isCritical)
        {
            if (isCritical)
            {
                _tags.Add(FromObject("sparkle:criticalUpdate"));
            }

            return this;
        }

        public AppcastItemBuilder WithVersion(string bundleVersion, string bundleVersionShort = null)
        {
            _enclosure.Add(FromObject("sparkle:version"), FromObject(bundleVersion));
            _enclosure.Add(FromObject("sparkle:shortVersionString"), FromObject(bundleVersionShort ?? bundleVersion));
            return this;
        }

        public AppcastItemBuilder WithDownloadUrl(string url)
        {
            _enclosure.Add(FromObject("url"), FromObject(url));
            return this;
        }

        public AppcastItemBuilder WithEdSignature(string signature)
        {
            _enclosure.Add(FromObject(@"sparkle:edSignature"), FromObject(signature));
            return this;
        }

        public SUAppcastItem ToAppcastItem()
        {
            return new SUAppcastItem(_dictionary);
        }

        public static AppcastItemBuilder Create()
        {
            return new AppcastItemBuilder();
        }
    }

    public class AppcastBuilder : NSObject
    {
        private List<AppcastItemBuilder> _appcastItems;

        public static AppcastBuilder Create()
        {
            return new AppcastBuilder();
        }

        public AppcastBuilder AddItem(AppcastItemBuilder item)
        {
            _appcastItems.Add(item);
            return this;
        }

        AppcastBuilder()
        {
            _appcastItems = new List<AppcastItemBuilder>();
        }
        
        public SUAppcast ToAppcast()
        {
            return new SUAppcast(NSArray.FromNSObjects(_appcastItems.Select(i => i.ToAppcastItem()).ToArray()));
        }
    }
}
