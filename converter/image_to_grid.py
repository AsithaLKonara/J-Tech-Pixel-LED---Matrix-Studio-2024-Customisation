from PIL import Image

def image_to_grid(image_path):
    img = Image.open(image_path).convert("RGB")
    img = img.resize((150, 150))
    grid_data = []
    for y in range(150):
        row = []
        for x in range(150):
            r, g, b = img.getpixel((x, y))
            row.append((r << 16) | (g << 8) | b)  # Pack RGB into 3 bytes
        grid_data.append(row)
    return grid_data