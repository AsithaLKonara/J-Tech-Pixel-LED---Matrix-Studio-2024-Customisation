from PyQt5.QtWidgets import QApplication, QMainWindow, QTableWidget
from PyQt5.QtGui import QColor

class PixelLEDWindow(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("J Tech Pixel LED")
        self.grid = QTableWidget(150, 150)  # 150x150 grid
        self.grid.setFixedSize(600, 600)   # 4x4 pixel size per LED
        self.grid.cellClicked.connect(self.toggle_pixel)
        self.setCentralWidget(self.grid)

    def toggle_pixel(self, row, col):
        item = self.grid.item(row, col)
        if not item:
            item = QTableWidgetItem()
            item.setBackground(QColor(0, 0, 0))  # Default OFF
            self.grid.setItem(row, col, item)
        color = QColor(255, 255, 255) if item.background().color().name() == "#000000" else QColor(0, 0, 0)
        item.setBackground(color)