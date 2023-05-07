using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CleanArchitectureCQRS.Shared.Abstractions.Commands;
using CleanArchitectureCQRS.Shared.Commands.CommandTypes;

namespace CleanArchitectureCQRS.Shared.Converters
{
    public class MessageJsonConverter : JsonConverter<ICommand>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsAssignableFrom(typeof(ICommand));
        }

        public override ICommand? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (!JsonDocument.TryParseValue(ref reader, out var doc))
            {
                throw new JsonException($"Failed to parse {nameof(JsonDocument)}");
            }

            if (!doc.RootElement.TryGetProperty("Type", out var type))
            {
                throw new JsonException("Could not detect the type discriminator property!");
            }

            var typeDiscriminator = type.GetString();
            var json = doc.RootElement.GetRawText();

            return typeDiscriminator switch
            {
                nameof(AddSampleEntityItem) => JsonSerializer.Deserialize<AddSampleEntityItem>(json, options),
                nameof(CreateSampleEntityWithItems) => JsonSerializer.Deserialize<CreateSampleEntityWithItems>(json, options),
                nameof(RemoveSampleEntity) => JsonSerializer.Deserialize<RemoveSampleEntity>(json, options),
                nameof(RemoveSampleEntityItem) => JsonSerializer.Deserialize<RemoveSampleEntityItem>(json, options),
                nameof(TakeItem) => JsonSerializer.Deserialize<TakeItem>(json, options),

                _ => throw new JsonException($"{typeDiscriminator} is not supported yet!")
            };
        }

        public override void Write(Utf8JsonWriter writer, ICommand value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

