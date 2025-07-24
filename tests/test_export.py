import os
import pytest
from export_engine import export_to_hex, export_to_bin, export_to_dat

def test_hex_export():
    sample_data = [[[255, 0, 0] for _ in range(150)] for _ in range(150)]
    export_to_hex(sample_data, "test.hex")
    assert os.path.exists("test.hex")
    with open("test.hex", "r") as f:
        lines = f.readlines()
        assert len(lines) > 0
    os.remove("test.hex")

def test_bin_export():
    sample_data = [[[255, 0, 0] for _ in range(150)] for _ in range(150)]
    export_to_bin(sample_data, "test.bin")
    assert os.path.exists("test.bin")
    with open("test.bin", "rb") as f:
        data = f.read()
        assert len(data) == 150 * 150 * 3  # 3 bytes per pixel
    os.remove("test.bin")

def test_dat_export():
    sample_data = [[[255, 0, 0] for _ in range(150)] for _ in range(150)]
    export_to_dat(sample_data, "test.dat")
    assert os.path.exists("test.dat")
    with open("test.dat", "rb") as f:
        data = f.read()
        assert len(data) == 4 + (150 * 150 * 4)  # 4-byte frame count + 4 bytes per pixel
    os.remove("test.dat")