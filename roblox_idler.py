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
class IdlerWindow(QMainWindow):
    """Roblox Idlers main window"""
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Roblox Idler")
        self.setFixedSize(WINDOW_SIZE, WINDOW_SIZE)
        centralWidget = QWidget(self)
        self.setCentralWidget(centralWidget)

def main():
    """Idlers main function"""
    idlerApp = QApplication([])
    idlerWindow = IdlerWindow()
    idlerWindow.show()
    sys.exit(idlerApp.exec())

if __name__ == "__main__":
    main()