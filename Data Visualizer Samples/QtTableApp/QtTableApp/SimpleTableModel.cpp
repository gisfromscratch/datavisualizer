#include "SimpleTableModel.h"

#include <QDebug>

SimpleTableModel::SimpleTableModel(QFile *file, QObject *parent)
    : QAbstractTableModel(parent), _file(file), _fileStream(new QTextStream(file)), _rowCount(0), _columnCount(0), _currentRowIndex(0)
{
    if (0 != file && file->open(QIODevice::ReadOnly))
    {
        // Read the whole file to initialize the column and row count
        while (!_fileStream->atEnd())
        {
            _currentLine = _fileStream->readLine();
            if (0 == _columnCount)
            {
                // Determine the column count
                QStringList tokens = _currentLine.split(',');
                _columnCount = tokens.length();
            }
            else
            {
                _rowCount++;
            }
        }

        // Reset the file position
        resetToFirstRow();
    }
}

int SimpleTableModel::rowCount(const QModelIndex&) const
{
    return _rowCount;
}

int SimpleTableModel::columnCount(const QModelIndex&) const
{
    return _columnCount;
}

QVariant SimpleTableModel::data(const QModelIndex &index, int role) const
{
    if (Qt::DisplayRole != role)
    {
        return QVariant();
    }

    // Validate the current file position
    if (index.row() < _currentRowIndex)
    {
        // Reset the file position
        resetToFirstRow();
    }

    // Validate if the current row is a match
    bool rowFound = _currentRowIndex == index.row();
    if (!rowFound)
    {
        // Obtain the data by reading the specified line
        for (; !_fileStream->atEnd() && _currentRowIndex < index.row(); _currentRowIndex++)
        {
            _currentLine = _fileStream->readLine();
        }
        rowFound = _currentRowIndex == index.row();
        if (_fileStream->atEnd())
        {
            // Reset the file position
            resetToFirstRow();
        }
    }
    if (!rowFound)
    {
        return QString("NO ROW");
    }

    QStringList tokens = _currentLine.split(',');
    if (tokens.length() <= index.column())
    {
        return QString("NO COLUMN");
    }

    return tokens.at(index.column());
}

void SimpleTableModel::resetToFirstRow() const
{
    _fileStream->seek(0);
    if (!_fileStream->atEnd())
    {
        // Read the header column
        _fileStream->readLine();
    }
    _currentRowIndex = -1;
}
