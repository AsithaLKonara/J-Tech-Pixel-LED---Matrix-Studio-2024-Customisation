import struct

def export_to_hex(grid_data, filename):
    with open(filename, "w") as f:
        for frame in grid_data:
            for row in frame:
                for pixel in row:
                    # Convert RGB to Intel HEX format
                    f.write(f":02000004{struct.pack('>H', pixel).hex()}\n")

def export_to_bin(grid_data, filename):
    with open(filename, "wb") as f:
        for frame in grid_data:
            for row in frame:
                for pixel in row:
                    f.write(struct.pack('B', pixel))  # 1 byte per pixel