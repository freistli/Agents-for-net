﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Agents.Protocols.Primitives;
using System.Text.Json;

namespace Microsoft.Agents.Protocols.Serializer
{
    internal class ChannelAccountConverter : ConnectorConverter<ChannelAccount>
    {
        protected override bool TryReadCollectionProperty(ref Utf8JsonReader reader, ChannelAccount value, string propertyName, JsonSerializerOptions options)
        {
            return false;
        }

        protected override bool TryReadGenericProperty(ref Utf8JsonReader reader, ChannelAccount value, string propertyName, JsonSerializerOptions options)
        {
            return false;
        }

        protected override void ReadExtensionData(ref Utf8JsonReader reader, ChannelAccount value, string propertyName, JsonSerializerOptions options)
        {
            var extensionData = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(ref reader, options);
            value.Properties.Add(propertyName, extensionData);
        }

        protected override bool TryReadExtensionData(ref Utf8JsonReader reader, ChannelAccount value, string propertyName, JsonSerializerOptions options)
        {
            if (propertyName.Equals(nameof(value.Properties)))
            {
                var propertyValue = System.Text.Json.JsonSerializer.Deserialize<object>(ref reader, options);

                foreach (var element in propertyValue.ToJsonElements())
                {
                    value.Properties.Add(element.Key, element.Value);
                }

                return true;
            }

            return false;
        }

        protected override bool TryWriteExtensionData(Utf8JsonWriter writer, ChannelAccount value, string propertyName)
        {
            if (propertyName.Equals(nameof(value.Properties)))
            {
                foreach (var extensionData in value.Properties)
                {
                    writer.WritePropertyName(extensionData.Key);
                    extensionData.Value.WriteTo(writer);
                }

                return true;
            }

            return false;
        }
    }
}
