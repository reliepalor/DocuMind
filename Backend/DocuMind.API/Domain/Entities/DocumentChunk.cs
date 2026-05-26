using System;

namespace DocuMind.Domain.Entities;

public class DocumentChunk
{ 
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DocumentId { get; set; }
    public int ChunkIndex { get; set; }
    public string Content { get; set; } = string.Empty;
    public byte[] Embedding { get; set; } = Array.Empty<byte>();

    public Document Document { get; set; } = null!;
}