# roblox_idler.py

"""Roblox Idler is an idling tool for Roblox built with Python and PyQT"""

import sys

from PyQt6.QtWidgets import (
    QApplication,
    QMainWindow,
    QWidget,
    QDialog,
    QDialogButtonBox,
    QLineEdit,
    QFormLayout,
    QLabel,
    QPushButton
)

WINDOW_SIZE = 235

app = QApplication([])
interval_widget = QWidget()
class Window(QMainWindow):
    def __init__(self):
        super().__init__(parent=None)
        self.setWindowTitle("Roblox Idler")
        self.setCentralWidget(interval_widget)

layout = QFormLayout()
layout.addRow("Enter a number from 1-19", QLineEdit())
layout.addWidget(QPushButton("Start"))

interval_widget.setLayout(layout)

if __name__ == "__main__":
    window = Window()
    window.show()
    sys.exit(app.exec())